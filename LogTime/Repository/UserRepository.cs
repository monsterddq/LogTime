using LogTime.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LogTime.Repository
{
    public class UserRepository : CommonRepositoryClass<User>
    {
        public UserRepository():base() {}
        public override User AddNew(User obj)
        {
            using (var tran = db.Database.BeginTransaction())
            {
                try
                {
                    db.Add(obj);
                    db.SaveChanges();
                    tran.Commit();
                    return obj;
                }
                catch (Exception e)
                {
                    tran.Rollback();
                    throw e;
                }

            }
        }

        public override User Find(string code) => db.Users.Find(code);

        public override List<User> GetAll() => db.Users.OrderByDescending(w => w.CreationDate).ToList();

        public override User Modify(User obj)
        {
            using (var tran = db.Database.BeginTransaction())
            {
                try
                {
                    obj.LastUpdateDate = DateTime.Now;
                    db.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.SaveChanges();
                    tran.Commit();
                    return obj;
                }
                catch (Exception e)
                {
                    tran.Rollback();
                    throw e;
                }
            }
        }

        public override User Remove(User obj)
        {
            using (var tran = db.Database.BeginTransaction())
            {
                try
                {
                    db.Users.Remove(obj);
                    db.SaveChanges();
                    tran.Commit();
                    return obj;
                }
                catch (Exception e)
                {
                    tran.Rollback();
                    throw e;
                }
            }

        }

        public User FindByUserName(string username) => db.Users.Where(w => w.Username.Equals(username)).SingleOrDefault();

        public User FindByEmail(string email) => db.Users.Where(w => w.Email.Equals(email)).SingleOrDefault();
    }
}
