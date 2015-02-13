using GifAtMe.DAL.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GifAtMe.SL.DTOs
{
    public class GifEntryDTO
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public string Url { get; set; }
        public string Keyword { get; set; }
        public int AlternateId { get; set; }

        static public implicit operator GifEntry(GifEntryDTO g)
        {
            return new GifEntry
            {
                ID = g.ID,
                UserName = g.UserName,
                Url = g.Url,
                Keyword = g.Keyword,
                AlternateId = g.AlternateId
            };
        }

        static public implicit operator GifEntryDTO(GifEntry g)
        {
            return new GifEntryDTO
            {
                ID = g.ID,
                UserName = g.UserName,
                Url = g.Url,
                Keyword = g.Keyword,
                AlternateId = g.AlternateId
            };
        }
    }
}