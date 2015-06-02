using GifAtMe.Common.Domain;
using GifAtMe.Common.UnitOfWork;
using GifAtMe.Repository.Contexts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

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
    public abstract class GenericDomainTypeRepository<DomainType>
        where DomainType : IAggregateRoot
    {
        private readonly IUnitOfWork _unitOfWork;
        private GifAtMeContext _context;

        public GenericDomainTypeRepository(IUnitOfWork unitOfWork, IGifAtMeContextFactory contextFactory)
        {
            if (unitOfWork == null) throw new ArgumentNullException("Unit of work");
            _unitOfWork = unitOfWork;

            if (contextFactory == null) throw new ArgumentNullException("DbContextFactory");
            _context = contextFactory.Create();
        }

        /*public virtual DomainType FindById(IdType id)
        {
            DomainType domainObj;
            domainObj = _context.Set<DomainType>().SingleOrDefault<DomainType>(x => x.Id.Equals(id));

            if (domainObj != null)
            {
                return domainObj;
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
            IQueryable<DomainType> dbQuery = _context.Set<DomainType>();

            //Apply eager loading
            foreach (Expression<Func<DomainType, object>> navigationProperty in navigationProperties)
                dbQuery = dbQuery.Include<DomainType, object>(navigationProperty);

            list = dbQuery
                .AsNoTracking()
                .ToList<DomainType>();
            return list;
        }

        public virtual IList<DomainType> GetList(Func<DomainType, bool> where,
            params Expression<Func<DomainType, object>>[] navigationProperties)
        {
            List<DomainType> list;
            IQueryable<DomainType> dbQuery = _context.Set<DomainType>();

            //Apply eager loading
            foreach (Expression<Func<DomainType, object>> navigationProperty in navigationProperties)
                dbQuery = dbQuery.Include<DomainType, object>(navigationProperty);

            list = dbQuery
                .AsNoTracking()
                .Where(where)
                .ToList<DomainType>();
            return list;
        }

        public virtual DomainType GetSingle(Func<DomainType, bool> where, int index,
             params Expression<Func<DomainType, object>>[] navigationProperties)
        {
            DomainType item = null;
            IQueryable<DomainType> dbQuery = _context.Set<DomainType>();

            //Apply eager loading
            foreach (Expression<Func<DomainType, object>> navigationProperty in navigationProperties)
                dbQuery = dbQuery.Include<DomainType, object>(navigationProperty);

            item = dbQuery.AsNoTracking().Where(where).ElementAtOrDefault(index);
            return item;
        }*/

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