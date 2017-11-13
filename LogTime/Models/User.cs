using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LogTime.Models
{
    public class User
    {
        public User()
        {
            this.Tasks = new List<Task>();
        }

        public User(string user_id, string username, string password, string fullname, string email, string reset_digest, DateTime? reset_sent_at, DateTime create_at, DateTime? update_at)
        {
            this.UserId = user_id;
            this.Username = username;
            this.Password = password;
            this.FullName = fullname;
            this.Email = email;
            this.ResetDigest = reset_digest;
            this.ResetSentAt = reset_sent_at;
            this.CreateAt = create_at;
            this.UpdateAt = update_at;
        }

        public User(string user_id, string username, string password, string fullname, string email, string reset_digest, DateTime? reset_sent_at, DateTime create_at, DateTime? update_at, List<Task> tasks)
        {
            this.UserId = user_id;
            this.Username = username;
            this.Password = password;
            this.FullName = fullname;
            this.Email = email;
            this.ResetDigest = reset_digest;
            this.ResetSentAt = reset_sent_at;
            this.CreateAt = create_at;
            this.UpdateAt = update_at;
            Tasks = tasks;
        }
        [Key]
        public string UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string ResetDigest { get; set; }
        public Nullable<DateTime> ResetSentAt { get;set; }
        public DateTime CreateAt { get; set; }
        public Nullable<DateTime> UpdateAt { get; set; }
        public virtual List<Task> Tasks { get; set; }
    }
}
