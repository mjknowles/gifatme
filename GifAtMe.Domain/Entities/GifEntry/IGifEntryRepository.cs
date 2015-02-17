using GifAtMe.Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GifAtMe.Domain.Entities.GifEntry
{
    public interface IGifEntryRepository : IAggregateRootRepository<GifEntry, int>
    {
        IEnumerable<GifEntry> GetAllByUserName(string userName);
        GifEntry GetByNonIdFields(string userName, string keyword, int alternateId);
    }
}
