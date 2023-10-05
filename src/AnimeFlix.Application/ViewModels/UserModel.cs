using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeFlix.Application.ViewModels
{
    public class UserViewModel : ViewModel
    {
        public string Name { get;  set; }
        public string Bio { get;  set; }
        public string Email { get;  set; }
        public string Phone { get;  set; }
        public int[] FavoriteAnimes { get;  set; }
        public int[] FavoriteCharacters { get;  set; }
        public DateTime CreatedAt { get;  set; }
    }
}
