using GifAtMe.Common.Domain;
using System.Collections.Generic;

namespace GifAtMe.Domain.Entities.GifEntry
{
    public interface IGifEntryRepository : IAggregateRootRepository<GifEntry, int>
    {
        List<GifEntry> GetAllForAllUserIds();

        List<GifEntry> GetAllForUserId(string userId);

        List<GifEntry> GetAllForUserIdAndKeyword(string userId, string keyword);

        GifEntry GetGifEntryForUserIdAndKeywordAndAlternateIndex(string userId, string keyword, int altIndex);
    }
}