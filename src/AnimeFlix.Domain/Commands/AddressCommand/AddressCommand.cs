using AnimeFlix.Domain.Core.Commands;

namespace AnimeFlix.Domain.Commands.AddressCommand
{
    public abstract class AddressCommand : Command
    {

        public int Id { get; protected set; }
        public string Street { get; protected set; }
        public int Number { get; protected set; }
        public string Complement { get; protected set; }
        public string City { get; protected set; }
        public string State { get; protected set; }
        public string  Country { get; protected set; }
        public string ZipCode { get; protected set; }
        public int UserId { get; protected set; }

        public void SetId(int id) => Id = id;
    }
}
