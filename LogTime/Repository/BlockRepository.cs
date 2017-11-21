using LogTime.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogTime.Repository
{
    public class BlockRepository : CommonRepositoryClass<Block>
    {
        public BlockRepository() : base() { }

        public override Block AddNew(Block obj)
        {
            using (var tran = db.Database.BeginTransaction())
            {
                try
                {
                    db.Blocks.Add(obj);
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

        public override Block Find(string code) => db.Blocks.Find(code);

        public override List<Block> GetAll() => db.Blocks.OrderByDescending(w => w.StartDate).ToList();
        public override Block Modify(Block obj)
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

        public override Block Remove(Block obj)
        {
            using (var tran = db.Database.BeginTransaction())
            {
                try
                {
                    db.Blocks.Remove(obj);
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

        public List<Block> GetByTask(string TaskCode) => db.Blocks.Where(w => w.TaskCode.Equals(TaskCode)).OrderByDescending(w=>w.StartDate).ToList();
    }
}
