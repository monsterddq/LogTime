using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LogTime.DTO
{
    public class UserDTO
    {
        public UserDTO()
        {
        }

        public UserDTO(string user_id, string username, string password, string fullname, string email, string reset_digest, DateTime? reset_sent_at, DateTime creation_date, DateTime? last_update_date)
        {
            this.user_id = user_id;
            this.username = username;
            this.password = password;
            this.fullname = fullname;
            this.email = email;
            this.reset_digest = reset_digest;
            this.reset_sent_at = reset_sent_at;
            this.creation_date = creation_date;
            this.last_update_date = last_update_date;
        }
        public string user_id { get; set; }
        [Required]
        [MinLength(2)]
        [MaxLength(255)]
        [RegularExpression(@"^[A-z0-9]*$")]
        public string username { get; set; }
        [Required]
        [MinLength(6)]
        public string password { get; set; }
        public string fullname { get; set;  }
        [Required]
        [EmailAddress]
        public string email { get; set; }
        public string reset_digest { get; set; }
        public Nullable<DateTime> reset_sent_at { get; set; }
        public DateTime creation_date { get; set; }
        public Nullable<DateTime> last_update_date { get; set; }
    }
}
