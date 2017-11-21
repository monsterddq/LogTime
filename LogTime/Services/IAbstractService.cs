using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LogTime.DTO;

namespace LogTime.Services
{
    public interface IAbstractService<D, K, E>
    {
        Pager<D> LoadAll(int CurrentPage, int NoOfRowInPage);
        D FetchByKey(K key);
        D Add(D obj);
        D Edit(D obj);
        D Delete(K key);
    }
}
