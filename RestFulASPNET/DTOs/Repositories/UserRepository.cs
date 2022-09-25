using System;
using RestFulASPNET.DTOs.Entities;
using RestFulASPNET.Configs;
namespace RestFulASPNET.DTOs.Repositories
{
	public class UserRepository : GenericRepository<User> ,IUserRepository
    {
		public UserRepository(DataContext db) : base(db)
        {
		}

        public User GetUserByName(string username)
        {
            return db.User.Where(x => x.Name == username).FirstOrDefault();
        }

        public User GetUserById(int id)
        {
            return db.User.Where(x => x.Id == id).FirstOrDefault();
        }

        public void CreateUser(User model)
        {
            db.Add(model);
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}

