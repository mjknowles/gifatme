using GifAtMe.Common.Domain;
using GifAtMe.Common.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GifAtMe.Repository
{
    public class EfUnitOfWork : IUnitOfWork, IDisposable
    {
        private GifAtMeContext _context;

        public EfUnitOfWork()
        {
            _context = new GifAtMeContext();
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

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposing)
            {
                return;
            }

            if (_context == null)
            {
                return;
            }

            _context.Dispose();
            _context = null;
        }
    }
}
