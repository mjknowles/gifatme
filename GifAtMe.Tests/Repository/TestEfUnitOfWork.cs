using GifAtMe.Common.Domain;
using GifAtMe.Common.UnitOfWork;
using System.Collections.Generic;

namespace GifAtMe.Tests.Repository
{
    public class TestEfUnitOfWork<T> : IUnitOfWork
        where T : EntityBase<int>
    {
        public List<T> TestEntities { get; set; }

        public List<T> AddedEntities { get; set; }

        public List<T> UpdatedEntities { get; set; }

        public List<T> DeletedEntities { get; set; }

        public TestEfUnitOfWork()
        {
            TestEntities = new List<T>();
            AddedEntities = new List<T>();
            UpdatedEntities = new List<T>();
            DeletedEntities = new List<T>();
        }

        public void RegisterInsertion(IAggregateRoot aggregateRoot)
        {
            AddedEntities.Add((T)aggregateRoot);
        }

        public void RegisterUpdate(IAggregateRoot aggregateRoot)
        {
            UpdatedEntities.Add((T)aggregateRoot);
        }

        public void RegisterDeletion(IAggregateRoot aggregateRoot)
        {
            DeletedEntities.Add((T)aggregateRoot);
        }

        public void Commit()
        {
            foreach (T entity in AddedEntities)
            {
                TestEntities.Add(entity);
            }
            foreach (T entity in UpdatedEntities)
            {
                int index = TestEntities.FindIndex(x => x.Id == ((T)entity).Id);
                TestEntities[index] = (T)entity;
            }
            foreach (T entity in DeletedEntities)
            {
                TestEntities.Remove(entity);
            }
            AddedEntities.Clear();
            UpdatedEntities.Clear();
            DeletedEntities.Clear();
        }
    }
}