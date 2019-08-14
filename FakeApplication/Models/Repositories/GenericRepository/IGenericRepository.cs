using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FakeApplication.Models.Repositories.GenericRepository
{
    interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> GetAll();

        T GetById(int id);

        T Add(T entity);

        T Update(T entity);

        void Delete(T entity);

        int Count();
    }
}
