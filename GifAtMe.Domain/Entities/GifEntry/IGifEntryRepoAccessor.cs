using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GifAtMe.Domain.Entities.GifEntry
{
    public interface IGifEntryRepoAccessor
    {
        GifEntry FindById(int id);
        GifEntry FindByNonIdFields(string userName, string keyword, int? alternateIndex);
        IEnumerable<GifEntry> GetAllByUserNameAndKeyword(string userName, string keyword);
        void Insert(GifEntry gifEntry);
        void Update(GifEntry gifEntry);
        void Delete(GifEntry gifEntry);
    }
}
