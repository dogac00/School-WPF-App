using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace SchoolApp
{
    public class SchoolDbContext : DbContext
    {
        private static string connectionString =
            "Server=(localdb)\\MSSQLLocalDB; Database=SchoolDb; Trusted_Connection=True;";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
    }
}
