using GifAtMe.Common.Domain;
using GifAtMe.Common.UnitOfWork;
using GifAtMe.Repository.Contexts;
using GifAtMe.Repository.DatabaseModels;
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
    public abstract class GenericDomainTypeRepository<DomainType, DbType>
        where DomainType : IAggregateRoot
    {
        private readonly IUnitOfWork _unitOfWork;
        internal GifAtMeContext _context;

        public GenericDomainTypeRepository(IUnitOfWork unitOfWork, IGifAtMeContextFactory contextFactory)
        {
            if (unitOfWork == null) throw new ArgumentNullException("Unit of work");
            _unitOfWork = unitOfWork;

            if (contextFactory == null) throw new ArgumentNullException("DbContextFactory");
            _context = contextFactory.Create();
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