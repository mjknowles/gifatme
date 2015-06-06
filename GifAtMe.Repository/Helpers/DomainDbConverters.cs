using GifAtMe.Domain.Entities.GifEntry;
using GifAtMe.Domain.Entities.User;
using GifAtMe.Repository.DatabaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GifAtMe.Repository.Helpers
{
    public static class DomainDbConverter
    {
        public static GifEntry ConvertToDomain(this GifEntryDb gifEntryDb)
        {
            if (gifEntryDb != null)
            {
                GifEntry gifEntry = new GifEntry()
                {
                    Id = gifEntryDb.Id,
                    UserId = gifEntryDb.UserId,
                    Url = gifEntryDb.Url,
                    Keyword = gifEntryDb.Keyword
                };
                return gifEntry;
            }
            else
                return new GifEntry();
        }

        public static GifEntryDb ConvertToDatabase(this GifEntry gifEntry)
        {
            if (gifEntry != null)
            {
                GifEntryDb gifEntryDb = new GifEntryDb()
                {
                    Id = gifEntry.Id,
                    UserId = gifEntry.UserId,
                    Url = gifEntry.Url,
                    Keyword = gifEntry.Keyword

                };
                return gifEntryDb;
            }
            else
                return new GifEntryDb();
        }

        public static User ConvertToDomain(this UserDb userDb)
        {
            if (userDb != null)
            {
                User user = new User()
                {
                    Id = userDb.Id,
                    SlackUserName = userDb.SlackUserName,
                    SlackUserId = userDb.SlackUserId,
                    SlackTeamId = userDb.SlackTeamId,
                    SlackTeamName = userDb.SlackTeamName,
                    SlackTeamUrl = userDb.SlackTeamUrl,
                    GifEntries = new List<GifEntry>()
                };
                foreach (GifEntryDb gedb in userDb.GifEntries)
                {
                    user.GifEntries.Add(gedb.ConvertToDomain());
                }
                return user;
            }
            else
                return new User();
        }
    }
}
