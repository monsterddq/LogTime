using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LogTime.Models;
using Microsoft.EntityFrameworkCore;

namespace LogTime.Repository
{
    public class TypeRepository : CommonRepositoryClass<LogTime.Models.Type>
    {
        public TypeRepository() : base() { }
        public override Models.Type AddNew(Models.Type obj)
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

        public override Models.Type Find(string code) => db.Types.Find(code);

        public override List<Models.Type> GetAll() => db.Types.OrderByDescending(w => w.CreationDate).ToList();

        public override Models.Type Modify(Models.Type obj)
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

        public override Models.Type Remove(Models.Type obj)
        {
            using (var tran = db.Database.BeginTransaction())
            {
                try
                {
                    db.Types.Remove(obj);
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

        public List<Models.Type> GetByCreator(string UserName) => db.Types.Where(w => w.CreatorUserName.Equals(UserName)).ToList();
        public List<Models.Type> GetByCreator(string UserId, string none) => db.Types.Include(w=>w.User).Where(w => w.User.UserId.Equals(UserId)).ToList();
    }
}
