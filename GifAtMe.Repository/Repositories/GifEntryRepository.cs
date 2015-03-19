using GifAtMe.Common.UnitOfWork;
using GifAtMe.Domain.Entities.GifEntry;
using GifAtMe.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GifAtMe.Repository.Repositories
{
    public class GifEntryRepository : GenericDomainTypeRepository<GifEntry, int>, IGifEntryRepository
    {
        public GifEntryRepository(IUnitOfWork unitOfWork) : base(unitOfWork) { }
        public GifEntryRepository(IUnitOfWork unitOfWork, GifAtMeContext context) : base(unitOfWork, context) { }

        public IEnumerable<GifEntry> GetAllForUserName(string userName)
        {
            return this.GetList(g => g.UserName.Equals(userName, StringComparison.OrdinalIgnoreCase));
        }

        public IEnumerable<GifEntry> GetAllForUserNameAndKeyword(string userName, string keyword)
        {
            return this.GetList(g => g.UserName.Equals(userName, StringComparison.OrdinalIgnoreCase) &&
                g.Keyword.Equals(keyword,StringComparison.OrdinalIgnoreCase));
        }

        public GifEntry GetGifEntryForUserNameAndKeywordAndAlternateIndex(string userName, string keyword, int altIndex)
        {
            return this.GetSingle(g => g.UserName.Equals(userName, StringComparison.OrdinalIgnoreCase) &&
                g.Keyword.Equals(keyword, StringComparison.OrdinalIgnoreCase), altIndex);
        }

        public IEnumerable<string> GetAllUserNames()
        {
            return this.GetAll().GroupBy(g => g.UserName).Select(g => g.First().UserName);
        }
    }
}
