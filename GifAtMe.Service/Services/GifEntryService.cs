using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GifAtMe.SL.Services
{
    public class GifEntryService : IGifEntryService
    {
        /*private readonly IGifEntryRepository _gifEntryRepository;

        public GifEntryService()
        {
            _gifEntryRepository = new GifEntryRepository();
        }

        public GifEntryService(IGifEntryRepository gifEntryRepository)
        {
            _gifEntryRepository = gifEntryRepository;
        }
 
        public IList<GifEntryDTO> GetGifEntriesByUserName(string userName)
        {
            return _gifEntryRepository.GetList(g => g.UserName.Equals(userName)).Select(g => new GifEntryDTO { 
                ID = g.ID,
                UserName = g.UserName,
                Url = g.Url,
                Keyword = g.Keyword,
                AlternateId = g.AlternateId
            }).ToList<GifEntryDTO>();
        }

        public void AddGifEntry(params GifEntryDTO[] gifEntries)
        {
            _gifEntryRepository.Add(gifEntries.Select(g => new GifEntry {
                ID = g.ID,
                UserName = g.UserName,
                Url = g.Url,
                Keyword = g.Keyword,
                AlternateId = g.AlternateId
            }).ToArray<GifEntry>());
        }

        public void UpdateGifEntry(params GifEntryDTO[] gifEntries)
        {
            _gifEntryRepository.Update(gifEntries.Select(g => new GifEntry
            {
                ID = g.ID,
                UserName = g.UserName,
                Url = g.Url,
                Keyword = g.Keyword,
                AlternateId = g.AlternateId
            }).ToArray<GifEntry>());
        }

        public void RemoveGifEntry(params GifEntryDTO[] gifEntries)
        {
            _gifEntryRepository.Remove(gifEntries.Select(g => new GifEntry
            {
                ID = g.ID,
                UserName = g.UserName,
                Url = g.Url,
                Keyword = g.Keyword,
                AlternateId = g.AlternateId
            }).ToArray<GifEntry>());
        }*/
    }
}
