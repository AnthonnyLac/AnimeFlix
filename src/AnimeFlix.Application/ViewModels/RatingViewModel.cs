using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeFlix.Application.ViewModels
{
    public class RatingViewModel : ViewModel
    {
        public int AnimeId { get;  set; }
        public double AverageRating { get;  set; }
        public int TotalRatings { get;  set; }
        public DateTime LastUpdated { get;  set; }
    }
}
