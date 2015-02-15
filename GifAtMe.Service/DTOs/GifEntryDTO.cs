using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GifAtMe.Service.DTOs
{
    public class GifEntryDTO
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public string Url { get; set; }
        public string Keyword { get; set; }
        public int AlternateId { get; set; }
    }
}