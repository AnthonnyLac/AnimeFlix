using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AnimeFlix.Application.ViewModels
{
    public class UserViewModel : ViewModel
    {
        public string Name { get;  set; }
        public string Bio { get;  set; }
        public string Email { get;  set; }
        public string Phone { get;  set; }

        [JsonIgnore]
        public int[]? FavoriteAnimes { get;  set; }

        [JsonIgnore]
        public int[]? FavoriteCharacters { get;  set; }
        public DateTime CreatedAt { get;  set; }

    }
}
