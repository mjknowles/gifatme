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
        IEnumerable<GifEntry> GetAllForUserName(string userName);
        IEnumerable<GifEntry> GetAllForUserNameAndKeyword(string userName, string keyword);
        GifEntry GetGifEntryForUserNameAndKeywordAndAlternateIndex(string userName, string keyword, int altIndex);
        IEnumerable<string> GetAllUserNames();
    }
}
