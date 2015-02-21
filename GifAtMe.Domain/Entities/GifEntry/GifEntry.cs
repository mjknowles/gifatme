using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GifAtMe.Common.Domain;

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
            if(!IsValidUrl(Url))
            {
                AddBrokenRule(GifEntryBusinessRule.UrlMustStartwithHttpAndEndWithDotGif);
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
    }
}