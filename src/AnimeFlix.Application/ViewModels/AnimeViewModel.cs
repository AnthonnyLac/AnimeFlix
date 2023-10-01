using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AnimeFlix.Application.ViewModels
{
    public class AnimeViewModel
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Genre { get; set; }
        public int ReleaseYear { get; set; }
        public string CoverImage { get; set; }
        public string Trailer { get; set; }
    }
}
