using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CCL.Security;
using CCL.Security.Identify;
using DAL.Entity;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class DBContext : DbContext
    {
        public DbSet<Region> regions { get; set; }
        public DbSet<Locality> localitys { get; set; }
        public DbSet<District> districts { get; set; }
        public DbSet<User> users { get; set; }
        //public DbSet<Admin> users { get; set; }
        //public DbSet<Analyst> users { get; set; }
        //public DbSet<Interviewer> users { get; set; }

        /*public DBContext() : base()
        {
            //Database.EnsureCreated();
        }*/
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "server=localhost;database=country_info;password=1111;uid=admin;";
            
            optionsBuilder.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 24)));

        }

    }
}
