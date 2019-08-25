using FakeApplication.Models.EfDataContext;
using FakeApplication.Models.Entities;
using FakeApplication.Models.Repositories.GenericRepository;
using FakeApplication.Models.UoW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FakeApplication.Models.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly ApplicationContext _db;

        public UserRepository(ApplicationContext db) : base(db)
        {
            _db = db;
        }
        public User GetUserByEmailAndPassword(string email, string password)
        {
           User user = _db.Users.FirstOrDefault(u => u.Email == email && u.Password == password);

           return user;
        }

        public User GetUserByEmail(string email)
        {
            User user =  _db.Users.FirstOrDefault(u => u.Email == email);

            return user;
        }
    }
}
