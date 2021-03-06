﻿using GifAtMe.Common.Domain;

namespace GifAtMe.Domain.Entities.GifEntry
{
    public class GifEntryBusinessRule
    {
        public static readonly BusinessRule UserIdRequired = new BusinessRule("A gif entry must have a user name associated with it.");
        public static readonly BusinessRule UrlMustStartwithHttpAndEndWithDotGif = new BusinessRule("A gif entry must begin with 'http://' and end with '.gif'.");
        public static readonly BusinessRule GifSizeTooLarge = new BusinessRule("Gif size too large. Must be less than 4 MB.");
        public static readonly BusinessRule UrlNotReceived = new BusinessRule("URL not received.");
    }
}