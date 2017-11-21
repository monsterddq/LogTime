using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogTime.DTO
{
    public class BlockDTO
    {
        public BlockDTO()
        {
        }

        public BlockDTO(string block_code, DateTime start_date, DateTime? end_date, string block_name)
        {
            this.block_code = block_code;
            this.start_date = start_date;
            this.end_date = end_date;
            this.block_name = block_name;
        }

        public string block_code { get; set;}
        public DateTime start_date { get; set;}
        public Nullable<DateTime> end_date { get; set; }
        public string block_name { get; set; }
    }
}
