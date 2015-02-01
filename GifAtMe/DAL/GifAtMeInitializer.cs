using GifAtMe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GifAtMe.DAL
{
    public class GifAtMeInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<GifAtMeContext>
    {
        protected override void Seed(GifAtMeContext context)
        {
            var gifEntries = new List<GifEntry>
            {
                new GifEntry{UserName="mknowles",Url="http://imgur.com/STVntis",Keyword="rise",AlternateId=0},
                new GifEntry{UserName="mknowles",Url="http://imgur.com/rEYJesc",Keyword="thisguy",AlternateId=0},
            };

            gifEntries.ForEach(g => context.GifEntries.Add(g));
            context.SaveChanges();
        }
    }
}