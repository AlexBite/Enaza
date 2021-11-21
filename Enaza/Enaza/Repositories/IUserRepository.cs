using System.Collections.Generic;
using System.Threading.Tasks;
using Enaza.Models;

namespace Enaza.Repositories
{
	public interface IUserRepository
	{
		Task<List<UserModel>> GetAllUsers();
		Task<UserModel> GetUserById(int id);
		Task<UserModel> AddUser(UserModel user);
		Task<UserModel> MarkUserAsBlocked(int id);
		Task<UserModel> GetUserByLogin(int id);
	}
}