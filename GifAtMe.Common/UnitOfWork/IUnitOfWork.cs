using GifAtMe.Common.Domain;

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