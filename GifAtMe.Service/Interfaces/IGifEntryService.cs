using GifAtMe.Service.Messaging.GifEntries;

namespace GifAtMe.Service.Interfaces
{
    public interface IGifEntryService
    {
        GetGifEntryResponse GetGifEntry(GetGifEntryRequest getGifEntryRequest);

        GetGifEntriesResponse GetGifEntries(GetGifEntriesRequest getGifEntriesRequest);

        InsertGifEntryResponse InsertGifEntry(InsertGifEntryRequest insertGifEntryRequest);

        //UpdateGifEntryResponse UpdateGifEntry(UpdateGifEntryRequest updateGifEntryRequest);

        //DeleteGifEntryResponse DeleteGifEntry(DeleteGifEntryRequest deleteGifEntryRequest);
    }
}