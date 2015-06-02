using GifAtMe.Common.UnitOfWork;
using GifAtMe.Domain.Entities.GifEntry;
using GifAtMe.Repository.Contexts;
using System;
using System.Collections.Generic;

namespace GifAtMe.Repository.Repositories
{
    public class GifEntryRepository : GenericDomainTypeRepository<GifEntry>, IGifEntryRepository
    {
        public GifEntryRepository(IUnitOfWork unitOfWork, IGifAtMeContextFactory dbContextFactory)
            : base(unitOfWork, dbContextFactory)
        {
        }

        public GifEntry FindById(int id)
        {
            return ConvertToDomain(_context.Set<TrackDb>().Include(t => t.TrackStats).SingleOrDefault(t => t.Id.Equals(id)));
        }

        public IEnumerable<GifEntry> GetAllForAllUserIds()
        {
            return this.GetAll();
        }

        public IEnumerable<GifEntry> GetAllForUserId(string userId)
        {
            return this.GetList(g => g.UserId.Equals(userId, StringComparison.OrdinalIgnoreCase));
        }

        public IEnumerable<GifEntry> GetAllForUserIdAndKeyword(string userId, string keyword)
        {
            return this.GetList(g => g.UserId.Equals(userId, StringComparison.OrdinalIgnoreCase) &&
                g.Keyword.Equals(keyword, StringComparison.OrdinalIgnoreCase));
        }

        public GifEntry GetGifEntryForUserIdAndKeywordAndAlternateIndex(string userId, string keyword, int altIndex)
        {
            return this.GetSingle(g => g.UserId.Equals(userId, StringComparison.OrdinalIgnoreCase) &&
                g.Keyword.Equals(keyword, StringComparison.OrdinalIgnoreCase), altIndex);
        }
    }
}