using GifAtMe.Common.UnitOfWork;
using GifAtMe.Domain.Entities.GifEntry;
using System;
using System.Collections.Generic;

namespace GifAtMe.Repository.Repositories
{
    public class GifEntryRepository : GenericDomainTypeRepository<GifEntry, int>, IGifEntryRepository
    {
        public GifEntryRepository(IUnitOfWork unitOfWork, IDbContextFactory dbContextFactory)
            : base(unitOfWork, dbContextFactory)
        {
        }

        public IEnumerable<GifEntry> GetAllForAllUserNames()
        {
            return this.GetAll();
        }

        public IEnumerable<GifEntry> GetAllForUserName(string userName)
        {
            return this.GetList(g => g.UserName.Equals(userName, StringComparison.OrdinalIgnoreCase));
        }

        public IEnumerable<GifEntry> GetAllForUserNameAndKeyword(string userName, string keyword)
        {
            return this.GetList(g => g.UserName.Equals(userName, StringComparison.OrdinalIgnoreCase) &&
                g.Keyword.Equals(keyword, StringComparison.OrdinalIgnoreCase));
        }

        public GifEntry GetGifEntryForUserNameAndKeywordAndAlternateIndex(string userName, string keyword, int altIndex)
        {
            return this.GetSingle(g => g.UserName.Equals(userName, StringComparison.OrdinalIgnoreCase) &&
                g.Keyword.Equals(keyword, StringComparison.OrdinalIgnoreCase), altIndex);
        }
    }
}