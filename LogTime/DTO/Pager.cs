using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogTime.DTO
{
    public class Pager<T>
    {
        public int CurrentPage { get; set; }
        public int NoOfRowInPage { get; set; }
        public int TotalRow { get; set; }
        public int TotalPage { get; set; }
        public List<T> Results { get; set; }
    }
}
