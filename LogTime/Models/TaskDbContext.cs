using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogTime.Models
{
    public class TaskDbContext : DbContext
    {
        public TaskDbContext() : base()
        {
        }
        public virtual DbSet<Task> Tasks { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Type> Types { get; set; }
        public virtual DbSet<Block> Blocks { get; set; }
        public virtual DbSet<TaskType> TaskTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = task.db");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(w => w.UserId);
            modelBuilder.Entity<Task>().HasKey(w => w.TaskCode);
            modelBuilder.Entity<Block>().HasKey(w => w.BlockCode);
            modelBuilder.Entity<Type>().HasKey(w => w.TypeCode);
            modelBuilder.Entity<TaskType>().HasKey(w => new { w.TaskCode, w.TypeCode });
            base.OnModelCreating(modelBuilder);
        }
    }
}
