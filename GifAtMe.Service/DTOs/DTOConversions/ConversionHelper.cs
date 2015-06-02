using GifAtMe.Domain.Entities.GifEntry;
using GifAtMe.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GifAtMe.Service
{
    public static class ConversionHelper
    {
        public static GifEntryDTO ConvertToDTO(this GifEntry g, int altIndex)
        {
            return new GifEntryDTO
            {
                Id = g.Id,
                UserId = g.UserId,
                Url = g.Url,
                Keyword = g.Keyword,
                AlternateIndex = altIndex
            };
        }

        public static GifEntryDTO ConvertToDTO(this GifEntry g)
        {
            return new GifEntryDTO
            {
                Id = g.Id,
                UserId = g.UserId,
                Url = g.Url,
                Keyword = g.Keyword,
                AlternateIndex = 1
            };
        }

        public static IEnumerable<GifEntryDTO> ConvertToDTO(this IEnumerable<GifEntry> gifEntries)
        {
            List<GifEntryDTO> gifEntryDTOs = new List<GifEntryDTO>();
            var groupedGifEntries = gifEntries.ToLookup(g => g.Keyword + g.UserId, StringComparer.OrdinalIgnoreCase);
            foreach (var key in groupedGifEntries)
            {
                int altIndex = 1;
                foreach (var gifEntry in key)
                {
                    gifEntryDTOs.Add(gifEntry.ConvertToDTO(altIndex));
                    altIndex++;
                }
            }
            return gifEntryDTOs;
        }
    }
}