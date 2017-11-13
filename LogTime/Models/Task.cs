using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LogTime.Models
{
    public class Task
    {
        public Task()
        {
            this.User = new User();
        }

        public Task(string task_code, DateTime start_time, DateTime? end_time, string name, int creator, User user)
        {
            this.TaskCode = task_code;
            this.StartTime = start_time;
            this.EndTime = end_time;
            this.Name = name;
            this.Creator = creator;
            User = user;
        }

        [Key]
        public string TaskCode { get; set; }
        public DateTime StartTime { get; set; }
        public Nullable<DateTime> EndTime { get; set; }
        public string Name { get; set; }
        public int Creator { get; set; }
        [ForeignKey("creator")]
        public virtual User User { get; set; }
    }
}
