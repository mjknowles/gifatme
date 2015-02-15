using GifAtMe.Domain.Entities.GifEntry;
using GifAtMe.Repository;
using GifAtMe.Repository.DatabaseObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GifAtMe.Repository.Repositories
{
    public class GifEntryRepository : GenericDomainTypeRepository<GifEntry, DatabaseGifEntry, int>, IGifEntryRepository
    {
        public override DatabaseGifEntry ConvertToDatabaseType(GifEntry domainType)
        {
            DatabaseGifEntry dbGifEntry = new DatabaseGifEntry()
            {
                Id = domainType.Id,
                UserName = domainType.UserName,
                AlternateId = domainType.AlternateId,
                Url = domainType.Url,
                Keyword = domainType.Keyword
            };
            return dbGifEntry;
        }

        public override GifEntry ConvertToDomainType(DatabaseGifEntry dbType)
        {
            GifEntry gifEntry = new GifEntry()
            {
                Id = dbType.Id,
                UserName = dbType.UserName,
                AlternateId = dbType.AlternateId,
                Url = dbType.Url,
                Keyword = dbType.Keyword
            };
            return gifEntry;
        }
    }
}
