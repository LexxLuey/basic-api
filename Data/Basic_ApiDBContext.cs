using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using basic_api.Models;

namespace basic_api.Data
{
    public class Basic_ApiDBContext : DbContext
    {
        public Basic_ApiDBContext(DbContextOptions<Basic_ApiDBContext> options) : base(options) { }
        
        public DbSet<SuperHero> SuperHeroes { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Course> Courses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>().ToTable("Course");
            modelBuilder.Entity<Enrollment>().ToTable("Enrollment");
            modelBuilder.Entity<Student>().ToTable("Student");
        }        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 18));
            string connectionString = "server=localhost;port=3308;database=basic_api;user=root;password=''";
            optionsBuilder.UseMySql(connectionString, serverVersion);        
        }
     }
}