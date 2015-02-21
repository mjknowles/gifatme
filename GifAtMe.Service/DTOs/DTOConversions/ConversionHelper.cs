﻿using GifAtMe.Domain.Entities.GifEntry;
using GifAtMe.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GifAtMe.Service
{
    public static class ConversionHelper
    {
        public static GifEntryDTO ConvertToDTO(this GifEntry g)
        {
            return new GifEntryDTO
            {
                ID = g.Id,
                UserName = g.UserName,
                Url = g.Url,
                Keyword = g.Keyword,
            };
        }

        public static IEnumerable<GifEntryDTO> ConvertToDTO(this IEnumerable<GifEntry> gifEntries)
        {
            List<GifEntryDTO> gifEntryDTOs = new List<GifEntryDTO>();
            foreach (GifEntry gifEntry in gifEntries)
            {
                gifEntryDTOs.Add(gifEntry.ConvertToDTO());
            }
            return gifEntryDTOs;
        }

    }
}
