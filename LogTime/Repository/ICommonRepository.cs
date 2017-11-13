using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogTime.Repository
{
    interface ICommonRepository<T>
    {
        List<T> GetAll();
        T Find(string code);
        T AddNew(T obj);
        T Modify(T obj);
        T Remove(T obj);
    }
}
