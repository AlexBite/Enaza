using System.Collections.Generic;
using System.Threading.Tasks;
using Enaza.Models;

namespace Enaza.Services
{
	public interface IUserService
	{
		Task<List<UserModel>> GetAllUsers();
		Task<UserModel> GetUser(int userId);
		Task<UserModel> AddUser(string login, string password, UserGroup userGroup);
		Task DeleteUser(int userId);
	}
}