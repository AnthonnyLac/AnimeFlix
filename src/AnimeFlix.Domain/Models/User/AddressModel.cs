
namespace AnimeFlix.Domain.Models.User
{
    public class AddressModel
    {
       public AddressModel(int id, string street, int number, string complement, string city, string state, string country, string zipCode)
        {
            Id = id;
            Street = street;
            Number = number;
            Complement = complement;
            City = city;
            State = state;
            Country = country;
            ZipCode = zipCode;
        }

        public AddressModel(string street, int number, string city, string state, string country, string zipCode)
        {
            Street = street;
            Number = number;
            City = city;
            State = state;
            Country = country;
            ZipCode = zipCode;
        }

        public AddressModel()
        {
        }

        public int Id { get; private set; }
        public string Street { get; private set; }
        public int Number { get; private set; }
        public string Complement { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string  Country { get; private set; }
        public string ZipCode { get; private set; }

        public void SetId(int id) => Id = id;

    }
}
