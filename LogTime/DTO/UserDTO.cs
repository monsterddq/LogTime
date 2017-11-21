using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogTime.DTO
{
    public class UserDTO
    {
        public UserDTO()
        {
        }

        public UserDTO(string user_id, string username, string password, string fullname, string email, string createion_date, string last_update_date)
        {
            this.user_id = user_id;
            this.username = username;
            this.password = password;
            this.fullname = fullname;
            this.email = email;
            this.createion_date = createion_date;
            this.last_update_date = last_update_date;
        }

        public string user_id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string fullname { get; set;  }
        public string email { get; set; }
        public string createion_date { get; set; }
        public string last_update_date { get; set; }
    }
}
