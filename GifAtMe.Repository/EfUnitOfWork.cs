using GifAtMe.Common.Domain;
using GifAtMe.Common.UnitOfWork;
using System.Data.Entity;

namespace GifAtMe.Repository
{
    public class EfUnitOfWork : IUnitOfWork
    {
        private DbContext _context;

        public EfUnitOfWork(IDbContextFactory dbContextFactory)
        {
            _context = dbContextFactory.Create();
        }

        public void RegisterInsertion(IAggregateRoot aggregateRoot)
        {
            _context.Entry(aggregateRoot).State = System.Data.Entity.EntityState.Added;
        }

        public void RegisterUpdate(IAggregateRoot aggregateRoot)
        {
            _context.Entry(aggregateRoot).State = System.Data.Entity.EntityState.Modified;
        }

        public void RegisterDeletion(IAggregateRoot aggregateRoot)
        {
            _context.Entry(aggregateRoot).State = System.Data.Entity.EntityState.Deleted;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}