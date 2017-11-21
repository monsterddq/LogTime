using LogTime.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogTime.Repository
{
    public abstract class CommonRepositoryClass<T> : ICommonRepository<T>
    {
        protected TaskDbContext db;
        public CommonRepositoryClass()
        {
            db = new TaskDbContext();
        }

        public T AddNew(T obj)
        {
            throw new NotImplementedException();
        }

        public T Find(string code)
        {
            throw new NotImplementedException();
        }

        public List<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public T Modify(T obj)
        {
            throw new NotImplementedException();
        }

        public T Remove(T obj)
        {
            throw new NotImplementedException();
        }
    }
}
