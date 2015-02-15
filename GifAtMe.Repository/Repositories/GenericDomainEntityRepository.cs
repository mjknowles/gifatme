using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq.Expressions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GifAtMe.Common.Domain;
using GifAtMe.Repository;
using GifAtMe.Domain.Entities;

namespace GifAtMe.Repository.Repositories
{
    /// <summary>
    /// Not used in this project since I'm converting from
    /// domain objects to database models, but good example
    /// for the future where domain pbjects == database objects
    /// </summary>
    /// <typeparam name="DomainType">
    /// Use domain type instead of IRootAggregate bc the domain type
    /// may have more useful properties/methods needed to convert to a db type
    /// </typeparam>
    /// <typeparam name="DomainType">The type that maps to the actual database table</typeparam>
    public abstract class GenericDomainTypeRepository<DomainType, DatabaseType, IdType> : IGenericDomainEntityRepository<DomainType, IdType>
        where DomainType : IAggregateRoot
        where DatabaseType : class
    {
        public virtual DomainType FindById(IdType id)
        {
            DatabaseType dbGifEntry;
            using (var context = new GifAtMeContext())
            {
                dbGifEntry = context.Set<DatabaseType>().Find(id);
            }

            if (dbGifEntry != null)
            {
                return ConvertToDomainType(dbGifEntry);
            }
            return default(DomainType);
        }

        /// <summary>
        /// Example:
        /// IGenericDataRepository<Department> repository = new GenericAggregateRepository<Department>();
        /// IList<Department> departments = repository.GetAll(d => d.Employees);
        /// </summary>
        /// <param name="navigationProperties"></param>
        /// <returns></returns>
        public virtual IList<DomainType> GetAll(params Expression<Func<DomainType, object>>[] navigationProperties)
        {
            List<DomainType> list;
            using (var context = new GifAtMeContext())
            {
                IQueryable<DomainType> dbQuery = context.Set<DomainType>();

                //Apply eager loading
                foreach (Expression<Func<DomainType, object>> navigationProperty in navigationProperties)
                    dbQuery = dbQuery.Include<DomainType, object>(navigationProperty);

                list = dbQuery
                    .AsNoTracking()
                    .ToList<DomainType>();
            }
            return list;
        }

        public virtual IList<DomainType> GetList(Func<DomainType, bool> where,
            params Expression<Func<DomainType, object>>[] navigationProperties)
        {
            List<DomainType> list;
            using (var context = new GifAtMeContext())
            {
                IQueryable<DomainType> dbQuery = context.Set<DomainType>();

                //Apply eager loading
                foreach (Expression<Func<DomainType, object>> navigationProperty in navigationProperties)
                    dbQuery = dbQuery.Include<DomainType, object>(navigationProperty);

                list = dbQuery
                    .AsNoTracking()
                    .Where(where)
                    .ToList<DomainType>();
            }
            return list;
        }

        public virtual DomainType GetSingle(Func<DomainType, bool> where,
             params Expression<Func<DomainType, object>>[] navigationProperties)
        {
            DomainType item = null;
            using (var context = new GifAtMeContext())
            {
                IQueryable<DomainType> dbQuery = context.Set<DomainType>();

                //Apply eager loading
                foreach (Expression<Func<DomainType, object>> navigationProperty in navigationProperties)
                    dbQuery = dbQuery.Include<DomainType, object>(navigationProperty);

                item = dbQuery
                    .AsNoTracking() //Don't track any changes for the selected item
                    .FirstOrDefault(where); //Apply where clause
            }
            return item;
        }

        public virtual void Insert(DomainType item)
        {
            using (var context = new GifAtMeContext())
            {

                DatabaseType databaseItem = ConvertToDatabaseType(item);
                context.Entry(databaseItem).State = System.Data.Entity.EntityState.Added;

                context.SaveChanges();
            }
        }

        public virtual void Update(DomainType item)
        {
            using (var context = new GifAtMeContext())
            {
                DatabaseType databaseItem = ConvertToDatabaseType(item);
                context.Entry(databaseItem).State = System.Data.Entity.EntityState.Modified;

                context.SaveChanges();
            }
        }

        public virtual void Delete(DomainType item)
        {
            using (var context = new GifAtMeContext())
            {
                DatabaseType databaseItem = ConvertToDatabaseType(item);
                context.Entry(databaseItem).State = System.Data.Entity.EntityState.Deleted;

                context.SaveChanges();
            }
        }

        public abstract DatabaseType ConvertToDatabaseType(DomainType domainType);
        public abstract DomainType ConvertToDomainType(DatabaseType databaseType);
    }
}
