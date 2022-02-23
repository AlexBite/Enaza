using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Enaza.Contexts;
using Enaza.Exceptions;
using Enaza.Models;
using Microsoft.Data.SqlClient;
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
			await Task.Delay(5 * 1000);
			user.CreatedDate = DateTime.UtcNow;
			var addedUser = await _dbContext.Users.AddAsync(user);
			try
			{
				await _dbContext.SaveChangesAsync();
			}
			catch (DbUpdateException ex)
			{
				if (!(ex.InnerException is SqlException sqlException))
					throw;

				if (sqlException.Number == 2601)
					throw new UserWithSameLoginAlreadyAddedException("");
			}

			return addedUser.Entity;
		}

		public async Task<UserModel> GetUserByLogin(string login)
		{
			var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Login == login);
			return user;
		}

		public async Task<bool> IsAdminUserExists()
		{
			var isAdminUserExists = await _dbContext.UserGroups.Include(ug => ug.Users)
				.AnyAsync(ug => ug.Code == UserGroup.Admin);

			return isAdminUserExists;
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

		public async Task MarkAsBlocked(UserModel user)
		{
			user.UserStateId = (int) UserState.Blocked;
			await _dbContext.SaveChangesAsync();
		}
	}
}