using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LogTime.Models
{
    public class TaskType
    {
        public TaskType()
        {}

        public TaskType(string taskCode, string typeCode, Task task, Type type)
        {
            TaskCode = taskCode;
            TypeCode = typeCode;
            Task = task;
            Type = type;
        }

        [Key]
        [Column(Order = 0)]
        public string TaskCode { get; set; }
        [Key]
        [Column(Order = 1)]
        public string TypeCode { get; set; }
        [ForeignKey("TaskCode")]
        public virtual Task Task { get; set; }
        [ForeignKey("TypeCode")]
        public virtual Type Type { get; set; }

    }
}
