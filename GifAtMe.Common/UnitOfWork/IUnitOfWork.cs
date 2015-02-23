using GifAtMe.Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GifAtMe.Common.UnitOfWork
{
    public interface IUnitOfWork
    {
        void RegisterInsertion(IAggregateRoot aggregateRoot);
        void RegisterUpdate(IAggregateRoot aggregateRoot);
        void RegisterDeletion(IAggregateRoot aggregateRoot);
        void Commit();
    }
}
