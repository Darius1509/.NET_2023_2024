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
            var validation = ValidateParameters(streetName, postalCode, city, country);
            if (validation != null) { return validation; }

            return Result<Address>.Success(new Address(streetName, postalCode, city, country));
        }

        public static Result<Address> Update(Guid addressId, string streetName, int postalCode, string city, string country)
        {
            if (addressId == Guid.Empty) { return Result<Address>.Failure("Address Id cannot be empty"); }

            var validation = ValidateParameters(streetName, postalCode, city, country);
            if (validation != null) { return validation; }

            var address = new Address(streetName, postalCode, city, country)
            {
                AddressId = addressId
            };

            return Result<Address>.Success(address);
        }
    
        private static Result<Address>? ValidateParameters(string streetName, int postalCode, string city, string country)
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
                return Result<Address>.Failure("City name cannot be empty");
            }
            if (string.IsNullOrEmpty(country))
            {
                return Result<Address>.Failure("Country name cannot be empty");
            }
            return null;
        }
    }
}
