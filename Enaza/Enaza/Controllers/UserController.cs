using System.Linq;
using System.Threading.Tasks;
using Enaza.DTO;
using Enaza.Exceptions;
using Enaza.Mappers;
using Enaza.Models;
using Enaza.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

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
		public async Task<IActionResult> GetUser(int id)
		{
			var userModel = await _userService.GetUser(id);
			if (userModel == null)
				return NotFound();

			var userDto = _userMapper.MapModelToDto(userModel);
			return Ok(userDto);
		}

		[HttpGet]
		public async Task<IActionResult> GetAllUsers()
		{
			var userModels = await _userService.GetAllUsers();
			var userDtoList = userModels.Select(u => _userMapper.MapModelToDto(u));
			return Ok(userDtoList);
		}

		[HttpPost]
		public async Task<IActionResult> AddUser([FromBody] AddUserRequestDto addUserRequestDto)
		{
			UserModel addedUser;
			try
			{
				addedUser = await _userService.AddUser(addUserRequestDto.Login, addUserRequestDto.Password,
					addUserRequestDto.UserGroup);
			}
			catch (UserWithSameLoginAlreadyAddedException e)
			{
				return Conflict(e.Message);
			}

			if (_environment.IsProduction())
				await Task.Delay(5 * 1000);

			return Ok(addedUser);
		}

		[HttpDelete("{id:int}")]
		public async Task<IActionResult> DeleteUser(int id)
		{
			await _userService.DeleteUser(id);
			return Ok();
		}
	}
}