using GifAtMe.Common.Domain;

namespace GifAtMe.Domain.ValueObjects
{
    public static class ValueObjectBusinessRule
    {
        public static readonly BusinessRule CityInAddressRequired = new BusinessRule("An address must have a city.");
    }
}