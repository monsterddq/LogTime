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
            this.Blocks = new List<Block>();
            this.TaskTypes = new List<TaskType>();
        }

        public Task(string taskCode, string taskName, string taskLink, DateTime lastUpdateDate, string creatorUserName)
        {
            TaskCode = taskCode;
            TaskName = taskName;
            TaskLink = taskLink;
            LastUpdateDate = lastUpdateDate;
            CreatorUserName = creatorUserName;
        }

        public Task(string taskCode, string taskName, string taskLink, DateTime lastUpdateDate, string creatorUserName, User user, List<Block> blocks, List<TaskType> taskTypes)
        {
            TaskCode = taskCode;
            TaskName = taskName;
            TaskLink = taskLink;
            LastUpdateDate = lastUpdateDate;
            CreatorUserName = creatorUserName;
            User = user;
            Blocks = blocks;
            TaskTypes = taskTypes;
        }

        [Key]
        public string TaskCode { get; set; }
        public string TaskName { get; set; }
        public string TaskLink { get; set; }
        private DateTime _CreationDate = DateTime.Now;
        public DateTime CreationDate { get => this._CreationDate; }
        public DateTime LastUpdateDate { get; set; }
        public string CreatorUserName { get; set; }


        [ForeignKey("CreatorUserName")]
        public virtual User User { get; set; }
        public virtual List<Block> Blocks { get; set; }
        public virtual List<TaskType> TaskTypes { get; set; }
    }
}
