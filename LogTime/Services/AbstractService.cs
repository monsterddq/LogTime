using LogTime.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LogTime.Utility;

namespace LogTime.Services
{
    public abstract class AbstractService<D, K, E> : IAbstractService<D, K, E>
    {
        public Paginator<D, E> paginator;

        public abstract D Add(D obj);
        public abstract D Delete(K key);
        public abstract D Edit(D obj);
        public abstract D FetchByKey(K key);
        public abstract DTO.Pager<D> LoadAll(int CurrentPage, int NoOfRowInPage);
    }
}
