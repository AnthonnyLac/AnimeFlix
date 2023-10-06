using AnimeFlix.Domain.Core.Commands;

namespace AnimeFlix.Domain.Commands.AddressCommand
{
    public abstract class AddressCommand : Command
    {

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
