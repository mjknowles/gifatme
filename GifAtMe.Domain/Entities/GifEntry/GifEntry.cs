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
        }
    }
}