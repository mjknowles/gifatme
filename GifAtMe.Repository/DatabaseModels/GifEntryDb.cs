using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GifAtMe.Repository.DatabaseModels
{
    public class GifEntryDb
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public string Url { get; set; }

        public string Keyword { get; set; }
    }
}
