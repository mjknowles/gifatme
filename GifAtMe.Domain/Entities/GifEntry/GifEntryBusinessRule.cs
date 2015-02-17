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
    }
}
