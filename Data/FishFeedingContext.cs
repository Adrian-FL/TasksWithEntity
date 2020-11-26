using FishFeedingTask.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FishFeedingTask.Data
{
    class FishFeedingContext : DbContext
    {
        public DbSet<Task> Tasks{ get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "Server=.;Database=FishFeedingTask;Trusted_Connection=True";

            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
