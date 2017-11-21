using LogTime.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LogTime.Repository
{
    public class TaskRepository : CommonRepositoryClass<LogTime.Models.Task>
    {
        public Task AddNew(Task obj)
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

        public Task Find(string code) => db.Tasks.Find(code);

        public List<Task> GetAll() => db.Tasks.OrderByDescending(w => w.StartTime).ToList();

        public Task Modify(Task obj)
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

        public Task Remove(Task obj)
        {
            using (var tran = db.Database.BeginTransaction())
            {
                try
                {
                    db.Tasks.Remove(obj);
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
