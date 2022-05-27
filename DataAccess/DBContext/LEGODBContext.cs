using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using DataAccess.Model;
using System.Web;

namespace DataAccess.DBContext
{
    public class LEGODBContext : DbContext
    {

        public LEGODBContext() : base("LEGOConnection")
        {
            Configuration.LazyLoadingEnabled = true;
            Configuration.ProxyCreationEnabled = true;
        }

        public DbSet<LEGOSet> LEGOSets { get; set; }

        public DbSet<LEGOBrick> LEGOBricks { get; set; }

        public DbSet<SetBrickLink> SetBrickLinks { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}