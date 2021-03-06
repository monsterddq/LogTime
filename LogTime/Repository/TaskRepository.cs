﻿using LogTime.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace LogTime.Repository
{
    public class TaskRepository : CommonRepositoryClass<LogTime.Models.Task>
    {
        public TaskRepository() : base() { }

        public override Task AddNew(Task obj)
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

        public override Task Find(string code) => db.Tasks.Find(code);

        public override List<Task> GetAll() => db.Tasks.OrderByDescending(w => w.CreationDate).ToList();

        public override Task Modify(Task obj)
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

        public override Task Remove(Task obj)
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

        public List<Task> GetByCreator(string UserName) => db.Tasks.Where(w => w.CreatorUserName.Equals(UserName)).ToList();
        public List<Task> GetByCreator(string UserId,string none) => db.Tasks.Include(w=>w.User).Where(w => w.User.UserId.Equals(UserId)).ToList();
        public List<Task> GetByType(string TypeCode) => db.Tasks.Include(w => w.TaskTypes).Where(w => w.TaskTypes.Any(e => e.TypeCode.Equals(TypeCode))).ToList();
    }
}
