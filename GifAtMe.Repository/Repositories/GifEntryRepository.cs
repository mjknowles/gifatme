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

        public IEnumerable<GifEntry> GetAllForUserName(string userName)
        {
            return this.GetAll(g => g.UserName.Equals(userName, StringComparison.OrdinalIgnoreCase));
        }

        public IEnumerable<GifEntry> GetAllForUserNameAndKeyword(string userName, string keyword)
        {
            return this.GetAll(g => g.UserName.Equals(userName, StringComparison.OrdinalIgnoreCase) &&
                g.Keyword.Equals(keyword,StringComparison.OrdinalIgnoreCase));
        }

        public GifEntry GetByNonIdFields(string userName, string keyword, int alternateId)
        {
            return this.GetSingle(g => g.UserName.Equals(userName, StringComparison.OrdinalIgnoreCase)
                && g.Keyword.Equals(keyword, StringComparison.OrdinalIgnoreCase)
                && g.AlternateId == alternateId);
        }
    }
}
