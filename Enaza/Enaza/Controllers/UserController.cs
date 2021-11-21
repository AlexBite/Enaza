using System.Linq;
using System.Threading.Tasks;
using Enaza.Mappers;
using Enaza.Services;
using Microsoft.AspNetCore.Mvc;

namespace Enaza.Controllers
{
	[ApiController]
	[Route("api/v1/users")]
	public class UserController : ControllerBase
	{
		private readonly IUserService _userService;
		private readonly IUserMapper _userMapper;

		public UserController(IUserService userService, IUserMapper userMapper)
		{
			_userService = userService;
			_userMapper = userMapper;
		}

		[HttpGet("{id:int}")]
		public async Task<IActionResult> GetUser(int id)
		{
			var userModel = await _userService.GetUser(id);
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
		public async Task<IActionResult> AddUser(string login, string password)
		{
			var userModel = await _userService.AddUser(login, password);
			await Task.Delay(5 * 1000);
			return Ok(userModel);
		}

		[HttpDelete("{id:int}")]
		public async Task<IActionResult> DeleteUser(int id)
		{
			await _userService.DeleteUser(id);
			return Ok();
		}
	}
}