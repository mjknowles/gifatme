using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GifAtMe.Common.Domain
{
    /// <summary>
    /// Expose the most common actions that are applicable across all 
    /// aggregate roots.
    /// </summary>
    /// <typeparam name="AggregateType"></typeparam>
    /// <typeparam name="IdType"></typeparam>
    public interface IAggregateRootRepository<AggregateType, IdType>
        : IReadOnlyAggregateRootRepository<AggregateType, IdType> where AggregateType
        : IAggregateRoot
    {
        void Update(AggregateType aggregate);
        void Insert(AggregateType aggregate);
        void Delete(AggregateType aggregate);
    }

}
