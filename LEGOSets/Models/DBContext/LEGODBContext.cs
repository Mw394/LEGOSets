using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace LEGOSets.Models.DBContext
{
    public class LEGODBContext : DbContext
    {

        public LEGODBContext() : base("LEGOConnection")
        {
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