using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GifAtMe.Models.DTOs
{
    public class GifEntryDTO
    {
        public string UserName { get; set; }
        public string Url { get; set; }
        public string Keyword { get; set; }
        public int KeywordVersion { get; set; }
    }
}