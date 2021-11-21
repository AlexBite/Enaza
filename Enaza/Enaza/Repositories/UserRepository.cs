using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Enaza.Contexts;
using Enaza.Models;
using Microsoft.EntityFrameworkCore;

namespace Enaza.Repositories
{
	public class UserRepository : IUserRepository
	{
		private readonly UsersContext _dbContext;

		public UserRepository(UsersContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task<List<UserModel>> GetAllUsers()
		{
			var users = await _dbContext.Users.Include(u => u.UserGroup)
				.Include(u => u.UserState)
				.ToListAsync();

			return users;
		}

		public async Task<UserModel> GetUserById(int id)
		{
			var user = await _dbContext.Users.Include(u => u.UserGroup)
				.Include(u => u.UserState)
				.FirstOrDefaultAsync(u => u.UserId == id);

			return user;
		}

		public async Task<UserModel> AddUser(UserModel user)
		{
			user.CreatedDate = DateTime.UtcNow;
			var addedUser = await _dbContext.Users.AddAsync(user);
			return addedUser.Entity;
		}

		public async Task<UserModel> GetUserByLogin(string login)
		{
			var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Login == login);
			return user;
		}

		public async Task SaveChanges()
		{
			await _dbContext.SaveChangesAsync();
		}

		public async Task<UserGroupModel> GetUserGroup(UserGroup userGroup)
		{
			var userGroupModel = await _dbContext.UserGroups.FirstOrDefaultAsync(ug => ug.Code == userGroup);
			return userGroupModel;
		}

		public async Task<UserStateModel> GetUserState(UserState userState)
		{
			var userStateModel = await _dbContext.UserStates.FirstOrDefaultAsync(us => us.Code == userState);
			return userStateModel;
		}
	}
}