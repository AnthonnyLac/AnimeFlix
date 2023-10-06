using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeFlix.Application.ViewModels
{
    public class AddressViewModel : ViewModel
    {
      public int Id { get; set; }
        public string Street { get; set; }
        public int Number { get; set; }
        public string Complement { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string  Country { get; set; }
        public string ZipCode { get; set; }
    }
}
