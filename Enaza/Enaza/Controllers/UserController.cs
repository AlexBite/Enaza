using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Enaza.DTO;
using Enaza.Exceptions;
using Enaza.Mappers;
using Enaza.Models;
using Enaza.Services;
using Microsoft.AspNetCore.Mvc;

namespace Enaza.Controllers
{
	[ApiController]
	[Route("api/v1/users")]
	public class UserController : ControllerBase
	{
		private readonly IUserMapper _userMapper;
		private readonly IUserService _userService;

		public UserController(IUserService userService,
			IUserMapper userMapper)
		{
			_userService = userService;
			_userMapper = userMapper;
		}

		[HttpGet("{id:int}")]
		public async Task<ActionResult<UserDto>> GetUser(int id)
		{
			var userModel = await _userService.GetUser(id);
			if (userModel == null)
				return NotFound(new BaseErrorResponseDto($"User with ID:{id} is not found"));

			var userDto = _userMapper.MapModelToDto(userModel);
			return Ok(userDto);
		}

		[HttpGet]
		public async Task<ActionResult<List<UserDto>>> GetAllUsers()
		{
			var userModels = await _userService.GetAllUsers();
			var userDtoList = userModels.Select(u => _userMapper.MapModelToDto(u));
			return Ok(userDtoList);
		}

		[HttpPost]
		public async Task<ActionResult<UserDto>> AddUser([FromBody] AddUserRequestDto addUserRequestDto)
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

			var userDto = _userMapper.MapModelToDto(addedUser);
			return Ok(userDto);
		}

		[HttpDelete("{id:int}")]
		public async Task<IActionResult> DeleteUser(int id)
		{
			try
			{
				await _userService.DeleteUser(id);
			}
			catch (UserNotFoundException e)
			{
				return NotFound(new BaseErrorResponseDto(e.Message));
			}

			return Ok();
		}
	}
}