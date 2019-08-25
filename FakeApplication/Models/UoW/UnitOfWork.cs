using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FakeApplication.Models.EfDataContext;
using FakeApplication.Models.Entities;
using FakeApplication.Models.Repositories;
using FakeApplication.Models.Repositories.GenericRepository;

namespace FakeApplication.Models.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext _context;

        private GenericRepository<User> _userRepository;
        private GenericRepository<Role> _roleRepository;
        private GenericRepository<Comment> _commentRepository;

        public UnitOfWork(ApplicationContext context)
        {
            _context = context;
        }


        public GenericRepository<User> UserRepository
        {
            get
            {
                return _userRepository = _userRepository ?? new UserRepository(_context);
            }
        }

        public GenericRepository<Role> RoleRepository
        {
            get
            {
                return _roleRepository = _roleRepository ?? new RoleRepository(_context);
            }
        }
        public GenericRepository<Comment> CommentRepository
        {
            get
            {
                return _commentRepository = _commentRepository ?? new GenericRepository<Comment>(_context);
            }
        }

        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}
