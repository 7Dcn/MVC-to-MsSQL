using MVC_FormPost_Uygulama1.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVC_FormPost_Uygulama1.Data
{
    public class NorthwindDbContext : DbContext
    {
        public NorthwindDbContext()
        {
            Database.Connection.ConnectionString = "server=.;database=Northwind; trusted_connection=true";
            Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }
    }
}