using FakeApplication.Models.EfDataContext;
using FakeApplication.Models.Entities;
using FakeApplication.Models.Repositories.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FakeApplication.Models.Repositories
{
    public class RoleRepository : GenericRepository<Role>, IRoleRepository
    {
        private readonly ApplicationContext _db;

        public RoleRepository(ApplicationContext db) : base(db)
        {
            _db = db;
        }
        public Role GetRoleByName(string name)
        {
            Role role = _db.Roles.FirstOrDefault(r => r.Name == "user");

            return role;
        }
    }
}
