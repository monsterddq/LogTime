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

        public abstract T AddNew(T obj);
        public abstract T Find(string code);
        public abstract List<T> GetAll();
        public abstract T Modify(T obj);
        public abstract T Remove(T obj);
    }
}
