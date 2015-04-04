using GifAtMe.Common.Domain;
using System.Collections.Generic;

namespace GifAtMe.Domain.Entities.GifEntry
{
    public interface IGifEntryRepository : IAggregateRootRepository<GifEntry, int>
    {
        IEnumerable<GifEntry> GetAllForAllUserNames();

        IEnumerable<GifEntry> GetAllForUserName(string userName);

        IEnumerable<GifEntry> GetAllForUserNameAndKeyword(string userName, string keyword);

        GifEntry GetGifEntryForUserNameAndKeywordAndAlternateIndex(string userName, string keyword, int altIndex);
    }
}