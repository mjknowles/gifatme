using GifAtMe.SL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GifAtMe.SL.Services
{
    public interface IGifEntryService
    {
        IList<GifEntryDTO> GetGifEntriesByUserName(string userName);
        void AddGifEntry(params GifEntryDTO[] gifEntries);
        void UpdateGifEntry(params GifEntryDTO[] gifEntries);
        void RemoveGifEntry(params GifEntryDTO[] gifEntries);
    }
}
