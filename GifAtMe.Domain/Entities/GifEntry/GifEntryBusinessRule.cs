using GifAtMe.Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GifAtMe.Domain.Entities.GifEntry
{
    public class GifEntryBusinessRule
    {
        public static readonly BusinessRule UserNameRequired = new BusinessRule("A gif entry must have a user name associated with it.");
        public static readonly BusinessRule UrlMustStartwithHttpAndEndWithDotGif = new BusinessRule("A gif entry must begin with 'http://' and end with '.gif'.");
        public static readonly BusinessRule GifSizeTooLarge = new BusinessRule("Gif size too large. Must be less than 4 MB.");
    }
}
