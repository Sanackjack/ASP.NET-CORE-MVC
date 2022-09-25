using System;
using RestFulASPNET.DTOs.Entities;
namespace RestFulASPNET.DTOs.Repositories
{
	public interface IUserRepository : IGenericRepository<User>
    {
        User GetUserByName(string username);
        User GetUserById(int id);
        void CreateUser(User model);
        void Save();

    }
}

