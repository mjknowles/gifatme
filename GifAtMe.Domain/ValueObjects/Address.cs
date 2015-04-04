using GifAtMe.Common.Domain;

namespace GifAtMe.Domain.ValueObjects
{
    /// <summary>
    /// NOTE THIS CLASS IS JUST AN EXAMPLE
    /// AND NOT ACUTALLY USED IN THIS PROJECT.
    ///
    /// In the example of a Customer entity,
    /// address is a value object that does not
    /// need to be tracked but does need its own
    /// business rules to validate.
    ///
    /// Instead of calling Validate, try calling the base
    /// classe's ThrowExceptionIfInvalid.
    ///
    /// </summary>
    public class Address : ValueObjectBase
    {
        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        public string City { get; set; }

        public string PostalCode { get; set; }

        protected override void Validate()
        {
            if (string.IsNullOrEmpty(City))
            {
                AddBrokenRule(ValueObjectBusinessRule.CityInAddressRequired);
            }
        }
    }
}