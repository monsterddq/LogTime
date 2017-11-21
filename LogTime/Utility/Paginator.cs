using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LogTime.DTO;
using AutoMapper;

namespace LogTime.Utility
{
    public class Paginator<D, E>
    {
        public Pager<D> Paginate(int CurrentPage, Pager<E> pager, int NoOfRowInPage)
        {
            NoOfRowInPage = ValidateNoOfRowInPage(NoOfRowInPage);
            CurrentPage = ValidateCurrentPage(CurrentPage);
            Pager<D> result = new Pager<D>
            {
                CurrentPage = CurrentPage,
                NoOfRowInPage = NoOfRowInPage,
                TotalRow = pager.TotalRow
            };
            result.TotalPage = (int)Math.Ceiling((double)result.TotalRow / NoOfRowInPage);
            return Mapper.Map<Pager<D>>(pager);
        }

        private int ValidateNoOfRowInPage(int NoOfRowInPage) => NoOfRowInPage <= Constant.ZERO ? Constant.NoOfRowDefaultValue : NoOfRowInPage;
        private int ValidateCurrentPage(int CurrentPage) => CurrentPage <= Constant.ZERO ? Constant.CurrentPageDefaultValue : CurrentPage;


    }
}
