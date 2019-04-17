using SimpleCrudApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SimpleCrudApp.DAL
{
    public class MyDbContext : DbContext
    {
        public MyDbContext() : base("MyDbContext")
        { }

        static MyDbContext()
        {
            Database.SetInitializer(new Initializer());
        }

        public DbSet<Employee> Employees { get; set; }
    }
}