using GifAtMe.Domain.Entities.GifEntry;
using GifAtMe.Repository.DatabaseModels;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace GifAtMe.Repository.Contexts
{
    public class GifAtMeContext : IdentityDbContext<UserDb>
    {
        public GifAtMeContext()
            : base("GifAtMeContext")
        {
            // Since application is layered, protect yourself from
            // lazy loading from a disposed of context
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        public virtual DbSet<GifEntryDb> GifEntries { get; set; }

        public static GifAtMeContext Create()
        {
            return new GifAtMeContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            /*modelBuilder.Entity<IdentityUserLogin>().HasKey<string>(l => l.UserId);
            modelBuilder.Entity<IdentityRole>().HasKey<string>(r => r.Id);
            modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId });
            modelBuilder.Entity<GifEntryDb>().HasKey<int>(r => r.Id);*/
        }
    }
}