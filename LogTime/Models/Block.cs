using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LogTime.Models
{
    public class Block
    {
        public Block() {}

        public Block(string blockCode, DateTime startDate, DateTime? endDate, string blockName, string taskCode)
        {
            BlockCode = blockCode;
            StartDate = startDate;
            EndDate = endDate;
            BlockName = blockName;
            TaskCode = taskCode;
        }

        public Block(string blockCode, DateTime startDate, DateTime? endDate, string blockName, string taskCode, Task task)
        {
            BlockCode = blockCode;
            StartDate = startDate;
            EndDate = endDate;
            BlockName = blockName;
            TaskCode = taskCode;
            Task = task;
        }

        [Key]
        public string BlockCode { get; set; }
        public DateTime StartDate { get; set; }
        public Nullable<DateTime> EndDate { get; set; }
        public string BlockName { get; set; }
        public string TaskCode { get; set; }
        [ForeignKey("TaskCode")]
        public virtual Task Task { get; set; }
    }
}
