using LogTime.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LogTime.Repository
{
    public class UserRepository : CommonRepositoryClass<User>
    {
        public UserRepository()
        {
        }

        public User AddNew(User obj)
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

        public User Find(string code) => db.Users.Find(code);

        public List<User> GetAll() => db.Users.OrderByDescending(w => w.StartTime).ToList();

        public User Modify(User obj)
        {
            using (var tran = db.Database.BeginTransaction())
            {
                try
                {
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

        public User Remove(User obj)
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
    }
}
