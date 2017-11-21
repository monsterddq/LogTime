using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LogTime.Models
{
    public class Type
    {
        public Type()
        {}

        public Type(string typeCode, string typeName, string creatorUserName, DateTime lastUpdateDate)
        {
            TypeCode = typeCode;
            TypeName = typeName;
            CreatorUserName = creatorUserName;
            LastUpdateDate = lastUpdateDate;
        }

        public Type(string typeCode, string typeName, string creatorUserName, DateTime creationDate, DateTime lastUpdateDate, User user) : this(typeCode, typeName, creatorUserName, lastUpdateDate)
        {
            User = user;
        }
        [Required]
        public string TypeCode { get; set; }
        public string TypeName { get; set; }
        public string CreatorUserName { get; set; }
        private DateTime _CreationDate = DateTime.Now;
        public DateTime CreationDate { get => this.CreationDate; }
        public DateTime LastUpdateDate { get; set; }


        [ForeignKey("CreatorUserName")]
        public virtual User User { get; set; }
    }
}
