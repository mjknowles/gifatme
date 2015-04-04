using GifAtMe.Service.Messaging.GifEntries;

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