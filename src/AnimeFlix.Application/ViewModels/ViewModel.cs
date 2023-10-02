using System.ComponentModel.DataAnnotations;

namespace AnimeFlix.Application.ViewModels
{
    public abstract class ViewModel
    {
        [Key]
        public int Id { get; set; }
    }
}
