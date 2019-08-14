using FakeApplication.Models.Entities;
using FakeApplication.Models.Repositories.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FakeApplication.Models.UoW
{
    public interface IUnitOfWork 
    {
        GenericRepository<User> UserRepository { get; }
        GenericRepository<Role> RoleRepository { get; }
        GenericRepository<Comment> CommentRepository { get; }

        void Commit();
    }
}
