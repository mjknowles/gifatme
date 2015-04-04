using GifAtMe.Domain.Entities.GifEntry;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace GifAtMe.Repository
{
    public class GifAtMeContext : DbContext
    {
        public GifAtMeContext()
            : base("GifAtMeContext")
        {
            // Since application is layered, protect yourself from
            // lazy loading from a disposed of context
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        public virtual DbSet<GifEntry> GifEntries { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}