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
        GifEntry FindByNonIdFields(string userName, string keyword, int? alternateId);
        IEnumerable<GifEntry> GetAllByUserNameAndKeyword(string userName, string keyword);
    }
}
