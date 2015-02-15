using GifAtMe.Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GifAtMe.Domain.Entities
{
    /// <summary>
    /// Taken from http://blog.magnusmontin.net/2013/05/30/generic-dal-using-entity-framework/
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IGenericDomainEntityRepository<DomainType, IdType> : IAggregateRootRepository<DomainType, IdType>
        where DomainType : IAggregateRoot
    {
        IList<DomainType> GetAll(params Expression<Func<DomainType, object>>[] navigationProperties);
        IList<DomainType> GetList(Func<DomainType, bool> where, params Expression<Func<DomainType, object>>[] navigationProperties);
        DomainType GetSingle(Func<DomainType, bool> where, params Expression<Func<DomainType, object>>[] navigationProperties);
    }

}
