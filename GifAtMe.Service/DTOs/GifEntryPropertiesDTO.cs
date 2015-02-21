using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GifAtMe.Service.DTOs
{
    public class GifEntryPropertiesDTO
    {
        public string UserName { get; set; }
        public string Url { get; set; }
        public string Keyword { get; set; }
        public int AlternateIndex { get; set; }
    }
}
