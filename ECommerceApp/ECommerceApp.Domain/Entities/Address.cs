using ECommerceApp.Domain.Common;

namespace ECommerceApp.Domain.Entities
{
    public class Address
    {
        private Address(string streetName, int postalCode, string city, string country)
        {
            AddressId = Guid.NewGuid();
            StreetName = streetName;
            PostalCode = postalCode;
            City = city;
            Country = country;
        }

        public Guid AddressId { get; private set; }
        public string StreetName { get; private set; }
        public int PostalCode { get; private set; }
        public string City { get; private set; }
        public string Country { get; private set; }

        public static Result<Address> Create(string streetName, int postalCode, string city, string country)
        {
            if (string.IsNullOrEmpty(streetName))
            {
                return Result<Address>.Failure("Street name cannot be empty");
            }
            if (postalCode <= 0)
            {
                return Result<Address>.Failure("Postal code cannot be less than or equal to zero");
            }
            if (string.IsNullOrEmpty(city))
            {
                return Result<Address>.Failure("City cannot be empty");
            }
            if (string.IsNullOrEmpty(country))
            {
                return Result<Address>.Failure("Country cannot be empty");
            }

            return Result<Address>.Success(new Address(streetName, postalCode, city, country));
        }
    }
}
