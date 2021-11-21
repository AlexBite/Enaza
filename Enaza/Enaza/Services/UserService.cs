using System.Collections.Generic;
using System.Threading.Tasks;
using Enaza.Models;
using Enaza.Repositories;

namespace Enaza.Services
{
	public class UserService : IUserService
	{
		private readonly IUserRepository _userRepository;

		public UserService(IUserRepository userRepository)
		{
			_userRepository = userRepository;
		}

		public async Task<List<UserModel>> GetAllUsers()
		{
			var users = await _userRepository.GetAllUsers();
			return users;
		}

		public async Task<UserModel> GetUser(int userId)
		{
			var user = await _userRepository.GetUserById(userId);
			return user;
		}

		public async Task<UserModel> AddUser(string login, string password)
		{
			var user = new UserModel
			{
				Login = login,
				Password = password,
				UserGroupId = 0,
				UserStateId = 0
			};

			var addedUser = await _userRepository.AddUser(user);
			return addedUser;
		}

		public async Task DeleteUser(int userId)
		{
			await _userRepository.MarkUserAsBlocked(userId);
		}
	}
}