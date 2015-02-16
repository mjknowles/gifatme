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
        private GifAtMeContext _ctx;

        public EfUnitOfWork()
        {
            _ctx = new GifAtMeContext();
        }

        public void RegisterInsertion(IAggregateRoot aggregateRoot)
        {
            _ctx.Entry(aggregateRoot).State = System.Data.Entity.EntityState.Added;
        }

        public void RegisterUpdate(IAggregateRoot aggregateRoot)
        {
            _ctx.Entry(aggregateRoot).State = System.Data.Entity.EntityState.Modified;
        }

        public void RegisterDeletion(IAggregateRoot aggregateRoot)
        {
            _ctx.Entry(aggregateRoot).State = System.Data.Entity.EntityState.Deleted;
        }

        public void Commit()
        {
            _ctx.SaveChanges();
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

            if (_ctx == null)
            {
                return;
            }

            _ctx.Dispose();
            _ctx = null;
        }
    }
}
