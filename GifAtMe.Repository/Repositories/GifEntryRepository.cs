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
    }
}
