using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogTime.DTO
{
    public class TaskDTO
    {
        public TaskDTO(string task_code, string task_name, string task_link, string creation_date, string last_update_date, string create_username)
        {
            this.task_code = task_code;
            this.task_name = task_name;
            this.task_link = task_link;
            this.creation_date = creation_date;
            this.last_update_date = last_update_date;
            this.create_username = create_username;
        }

        public TaskDTO()
        {
        }

        public string task_code { get; set; }
        public string task_name { get; set; }
        public string task_link { get; set; }
        public string creation_date { get; set; }
        public string last_update_date { get; set; }
        public string create_username { get; set; }
    }
}
