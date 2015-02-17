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
using GifAtMe.Common.UnitOfWork;

namespace GifAtMe.Repository.Repositories
{
    /// <summary>
    /// Taken from http://blog.magnusmontin.net/2013/05/30/generic-dal-using-entity-framework/
    /// </summary>
    /// <typeparam name="DomainType">
    /// Use domain type instead of IRootAggregate bc the domain type
    /// may have more useful properties/methods needed to convert to a db type
    /// </typeparam>
    /// <typeparam name="DomainType">The domain model saved to the db</typeparam>
    public abstract class GenericDomainTypeRepository<DomainType, IdType>
        where DomainType : class, IAggregateRoot
    {
        private readonly IUnitOfWork _unitOfWork;

        public GenericDomainTypeRepository(IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null) throw new ArgumentNullException("Unit of work");
            _unitOfWork = unitOfWork;
        }

        public virtual DomainType FindById(IdType id)
        {
            DomainType dbGifEntry;
            using (var context = new GifAtMeContext())
            {
                dbGifEntry = context.Set<DomainType>().Find(id);
            }

            if (dbGifEntry != null)
            {
                return dbGifEntry;
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
        public virtual IEnumerable<DomainType> GetAll(params Expression<Func<DomainType, object>>[] navigationProperties)
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
            _unitOfWork.RegisterInsertion(item);
        }

        public virtual void Update(DomainType item)
        {
            _unitOfWork.RegisterUpdate(item);
        }

        public virtual void Delete(DomainType item)
        {
            _unitOfWork.RegisterDeletion(item);
        }
    }
}
