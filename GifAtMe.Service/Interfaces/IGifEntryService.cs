using GifAtMe.Service.Messaging.GifEntries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GifAtMe.Service.Interfaces
{
    public interface IGifEntryService
    {
        GetGifEntryResponse GetGifEntry(GetGifEntryRequest getGifEntryRequest);
        GetGifEntriesResponse GetAllGifEntries(GetAllGifEntriesRequest getAllGifEntriesRequest);
        InsertGifEntryResponse InsertGifEntry(InsertGifEntryRequest insertGifEntryRequest);
        UpdateGifEntryResponse UpdateGifEntry(UpdateGifEntryRequest updateGifEntryRequest);
        DeleteGifEntryResponse DeleteGifEntry(DeleteGifEntryRequest deleteGifEntryRequest);
    }
}
