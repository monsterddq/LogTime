using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LogTime.Utility;

namespace LogTime.Models
{
    public static class TaskInitializer
    {
        public static void Initialze(TaskDbContext db)
        {
            using (var tran = db.Database.BeginTransaction())
            {
                db.Users.Add(new User()
                {
                    UserId = Utility.Utility.GenerateCode(Constant.PrefixUser),
                    Email="thaidq@d3plus.com",
                    FullName="Doãn Quốc Thái",
                    Password = Utility.Utility.Sha512Hash("12345678"),
                    Username = "djdd"
                });
                db.SaveChanges();
                tran.Commit();
            }
        }
    }
}
