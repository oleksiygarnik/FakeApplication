using FakeApplication.Models.Entities;
using FakeApplication.Models.Repositories.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FakeApplication.Models.Repositories
{
    interface IRoleRepository : IGenericRepository<Role>
    {
        Role GetRoleByName(string name);
    }
}
