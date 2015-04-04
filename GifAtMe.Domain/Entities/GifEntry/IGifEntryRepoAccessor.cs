using System.Collections.Generic;

namespace GifAtMe.Domain.Entities.GifEntry
{
    public interface IGifEntryRepoAccessor
    {
        GifEntry FindById(int id);

        GifEntry FindByNonIdFields(string userName, string keyword, int? alternateIndex);

        IEnumerable<GifEntry> GetAll();

        IEnumerable<GifEntry> GetAllForUserName(string userName);

        IEnumerable<GifEntry> GetAllForUserNameAndKeyword(string userName, string keyword);

        void Insert(GifEntry gifEntry);

        void Update(GifEntry gifEntry);

        void Delete(GifEntry gifEntry);
    }
}