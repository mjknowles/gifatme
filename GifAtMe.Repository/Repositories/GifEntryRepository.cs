using GifAtMe.Common.UnitOfWork;
using GifAtMe.Domain.Entities.GifEntry;
using GifAtMe.Repository.Contexts;
using GifAtMe.Repository.DatabaseModels;
using GifAtMe.Repository.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GifAtMe.Repository.Repositories
{
    public class GifEntryRepository : GenericDomainTypeRepository<GifEntry, GifEntryDb>, IGifEntryRepository
    {
        public GifEntryRepository(IUnitOfWork unitOfWork, IGifAtMeContextFactory dbContextFactory)
            : base(unitOfWork, dbContextFactory)
        {
        }

        public GifEntry FindById(int id)
        {
            return _context.GifEntries.Find(id).ConvertToDomain();
        }

        public List<GifEntry> GetAllForAllUserIds()
        {
            return _context.GifEntries.Select(g => g.ConvertToDomain()).ToList();
        }

        public List<GifEntry> GetAllForUserId(string userId)
        {
            return _context.GifEntries.Where(g => g.UserId.Equals(userId, StringComparison.OrdinalIgnoreCase))
                .Select(g => g.ConvertToDomain()).ToList();
        }

        public List<GifEntry> GetAllForUserIdAndKeyword(string userId, string keyword)
        {
            return _context.GifEntries.Where(g => g.UserId.Equals(userId, StringComparison.OrdinalIgnoreCase) &&
                g.Keyword.Equals(keyword, StringComparison.OrdinalIgnoreCase))
                .Select(g => g.ConvertToDomain()).ToList();
        }

        public GifEntry GetGifEntryForUserIdAndKeywordAndAlternateIndex(string userId, string keyword, int altIndex)
        {
            return GetAllForUserIdAndKeyword(userId, keyword).ElementAtOrDefault(altIndex);
        }
    }
}