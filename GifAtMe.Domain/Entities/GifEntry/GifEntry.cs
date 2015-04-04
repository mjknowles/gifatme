using GifAtMe.Common.Domain;
using System;
using System.Configuration;
using System.Net;

namespace GifAtMe.Domain.Entities.GifEntry
{
    public class GifEntry : EntityBase<int>, IAggregateRoot
    {
        public string UserName { get; set; }

        public string Url { get; set; }

        public string Keyword { get; set; }

        protected override void Validate()
        {
            if (string.IsNullOrEmpty(UserName))
            {
                AddBrokenRule(GifEntryBusinessRule.UserNameRequired);
            }

            if (String.IsNullOrEmpty(Url))
            {
                AddBrokenRule(GifEntryBusinessRule.UrlNotReceived);
            }
            else
            {
                if (!IsValidUrl(Url))
                {
                    AddBrokenRule(GifEntryBusinessRule.UrlMustStartwithHttpAndEndWithDotGif);
                }
                else
                {
                    if (!IsValidSizeGif(Url))
                    {
                        AddBrokenRule(GifEntryBusinessRule.GifSizeTooLarge);
                    }
                }
            }
        }

        private bool IsValidUrl(string url)
        {
            if (url.Length > 7)
            {
                string prefix = url.Substring(0, 7);
                string suffix = url.Substring(Math.Max(0, url.Length - 4));

                if (prefix.Equals("http://", StringComparison.OrdinalIgnoreCase) && suffix.Equals(".gif", StringComparison.OrdinalIgnoreCase))
                    return true;
            }
            return false;
        }

        private bool IsValidSizeGif(string url)
        {
            int length;
            using (WebClient client = new WebClient())
            {
                length = client.DownloadData(url).Length;
            }
            int limit;
            bool result = Int32.TryParse(ConfigurationManager.AppSettings["MaxGifSizeBytes"], out limit);
            if (result && (length < limit))
                return true;
            else
                return false;
        }
    }
}