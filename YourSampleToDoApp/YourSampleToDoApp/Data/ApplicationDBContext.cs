using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;
using YourSampleToDoApp.Models;

namespace YourSampleToDoApp.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
        }

        public DbSet<TaskCategory> TaskCategories { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
             => options.UseSqlite("Data Source=Tasks.db");
    }
}
