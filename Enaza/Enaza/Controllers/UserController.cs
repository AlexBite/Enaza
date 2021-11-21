using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Enaza.DTO;
using Enaza.Exceptions;
using Enaza.Mappers;
using Enaza.Models;
using Enaza.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Swashbuckle.AspNetCore.Annotations;

namespace Enaza.Controllers
{
	[ApiController]
	[Route("api/v1/users")]
	public class UserController : ControllerBase
	{
		private readonly IUserService _userService;
		private readonly IUserMapper _userMapper;
		private readonly IWebHostEnvironment _environment;

		public UserController(IUserService userService,
			IUserMapper userMapper,
			IWebHostEnvironment environment)
		{
			_userService = userService;
			_userMapper = userMapper;
			_environment = environment;
		}

		[HttpGet("{id:int}")]
		[SwaggerResponse(StatusCodes.Status200OK, Type = typeof(UserDto))]
		[SwaggerResponse(StatusCodes.Status404NotFound, Type = typeof(BaseErrorResponseDto),
			Description = "User not found")]
		public async Task<IActionResult> GetUser(int id)
		{
			var userModel = await _userService.GetUser(id);
			if (userModel == null)
				return NotFound(new BaseErrorResponseDto($"User with ID:{id} is not found"));

			var userDto = _userMapper.MapModelToDto(userModel);
			return Ok(userDto);
		}

		[HttpGet]
		[SwaggerResponse(StatusCodes.Status200OK, Type = typeof(List<UserDto>))]
		public async Task<IActionResult> GetAllUsers()
		{
			var userModels = await _userService.GetAllUsers();
			var userDtoList = userModels.Select(u => _userMapper.MapModelToDto(u));
			return Ok(userDtoList);
		}

		[HttpPost]
		[SwaggerResponse(StatusCodes.Status200OK, Type = typeof(UserDto))]
		[SwaggerResponse(StatusCodes.Status409Conflict, Type = typeof(BaseErrorResponseDto),
			Description = "Admin user is already added")]
		[SwaggerResponse(StatusCodes.Status409Conflict, Type = typeof(BaseErrorResponseDto),
			Description = "User with same login already exists")]
		public async Task<IActionResult> AddUser([FromBody] AddUserRequestDto addUserRequestDto)
		{
			UserModel addedUser;
			try
			{
				addedUser = await _userService.AddUser(addUserRequestDto.Login, addUserRequestDto.Password,
					addUserRequestDto.UserGroup);
			}
			catch (AdminUserAlreadyAddedException e)
			{
				return Conflict(new BaseErrorResponseDto(e.Message));
			}
			catch (UserWithSameLoginAlreadyAddedException e)
			{
				return Conflict(new BaseErrorResponseDto(e.Message));
			}

			if (_environment.IsProduction())
				await Task.Delay(5 * 1000);

			return Ok(addedUser);
		}

		[HttpDelete("{id:int}")]
		[SwaggerResponse(StatusCodes.Status200OK, Type = typeof(UserDto), Description = "User successfully blocked")]
		[SwaggerResponse(StatusCodes.Status404NotFound, Type = typeof(BaseErrorResponseDto),
			Description = "User not found")]
		public async Task<IActionResult> DeleteUser(int id)
		{
			await _userService.DeleteUser(id);
			return Ok();
		}
	}
}