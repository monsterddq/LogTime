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
            this.Types = new List<Type>();
        }

        public User(string user_id, string username, string password, string fullname, string email, string reset_digest, DateTime? reset_sent_at, DateTime? last_update_date)
            :this()
        {
            this.UserId = user_id;
            this.Username = username;
            this.Password = password;
            this.FullName = fullname;
            this.Email = email;
            this.ResetDigest = reset_digest;
            this.ResetSentAt = reset_sent_at;
            this.LastUpdateDate = last_update_date;
        }

        public User(string user_id, string username, string password, string fullname, string email, string reset_digest, DateTime? reset_sent_at, DateTime creation_date, DateTime? last_update_date, List<Task> tasks, List<Type> types)
            : this(user_id, username, password,fullname, email, reset_digest, reset_sent_at, last_update_date)
        {
            Tasks = tasks;
            Types = types;
        }
        [Required]
        public string UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string ResetDigest { get; set; }
        public Nullable<DateTime> ResetSentAt { get;set; }
        public DateTime _CreationDate = DateTime.Now;
        public DateTime CreationDate{ get => this._CreationDate; }
        public Nullable<DateTime> LastUpdateDate { get; set; }

        public virtual List<Task> Tasks { get; set; }
        public virtual List<Type> Types { get; set; }
    }
}
