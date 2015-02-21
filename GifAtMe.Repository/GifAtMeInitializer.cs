using GifAtMe.Domain.Entities.GifEntry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GifAtMe.Repository
{
    public class GifAtMeInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<GifAtMeContext>
    {
        protected override void Seed(GifAtMeContext context)
        {
            var gifEntries = new List<GifEntry>
            {
                new GifEntry{UserName="mknowles",Url="http://imgur.com/STVntis.gif",Keyword="rise"},
                new GifEntry{UserName="mknowles",Url="http://imgur.com/rEYJesc.gif",Keyword="thisguy"},
                new GifEntry{UserName="mknowles",Url="http://imgur.com/wJUHejF.gif",Keyword="highfive"},
            };

            gifEntries.ForEach(g => context.GifEntries.Add(g));
            context.SaveChanges();
        }
    }
}