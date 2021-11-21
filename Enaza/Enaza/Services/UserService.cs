using System.Collections.Generic;
using System.Threading.Tasks;
using Enaza.Exceptions;
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

		public async Task<UserModel> AddUser(string login, string password, UserGroup userGroup)
		{
			var userWithSameLogin = await _userRepository.GetUserByLogin(login);
			if (userWithSameLogin != null)
				throw new UserWithSameLoginAlreadyAddedException("User with same login is already added");

			var isAdminUserExists = await _userRepository.IsAdminUserExists();
			if (isAdminUserExists)
				throw new AdminUserAlreadyAddedException("Only one administrator can be in the system");

			var userGroupModel = await _userRepository.GetUserGroup(userGroup);
			var activeUserState = await _userRepository.GetUserState(UserState.Active);
			var user = new UserModel
			{
				Login = login,
				Password = password,
				UserGroup = userGroupModel,
				UserState = activeUserState
			};

			var addedUser = await _userRepository.AddUser(user);
			await _userRepository.SaveChanges();
			return addedUser;
		}

		public async Task DeleteUser(int userId)
		{
			var user = await _userRepository.GetUserById(userId);
			var blockedUserState = await _userRepository.GetUserState(UserState.Blocked);
			user.UserState = blockedUserState;
			await _userRepository.SaveChanges();
		}
	}
}