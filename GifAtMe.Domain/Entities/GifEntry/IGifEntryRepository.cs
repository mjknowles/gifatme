using GifAtMe.Common.Domain;
using System.Collections.Generic;

namespace GifAtMe.Domain.Entities.GifEntry
{
    public interface IGifEntryRepository : IAggregateRootRepository<GifEntry, int>
    {
        IEnumerable<GifEntry> GetAllForAllUserIds();

        IEnumerable<GifEntry> GetAllForUserId(string userId);

        IEnumerable<GifEntry> GetAllForUserIdAndKeyword(string userId, string keyword);

        GifEntry GetGifEntryForUserIdAndKeywordAndAlternateIndex(string userId, string keyword, int altIndex);
    }
}