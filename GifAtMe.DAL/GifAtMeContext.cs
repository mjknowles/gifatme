using GifAtMe.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace GifAtMe.DAL
{
    public class GifAtMeContext : DbContext
    {
        public GifAtMeContext() : base("GifAtMeContext") { }

        public DbSet<GifEntry> GifEntries { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}