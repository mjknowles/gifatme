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
    /// Not used in this project since I'm converting from
    /// domain objects to database models, but good example
    /// for the future where domain pbjects == database objects
    /// </summary>
    /// <typeparam name="DomainType">
    /// Use domain type instead of IRootAggregate bc the domain type
    /// may have more useful properties/methods needed to convert to a db type
    /// </typeparam>
    /// <typeparam name="DomainType">The type that maps to the actual database table</typeparam>
    public abstract class GenericDomainTypeRepository<DomainType, IdType> : IGenericDomainEntityRepository<DomainType, IdType>
        where DomainType : class, IAggregateRoot
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly GifAtMeContext _context;

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
