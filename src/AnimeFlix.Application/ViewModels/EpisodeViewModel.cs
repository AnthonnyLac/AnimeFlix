namespace AnimeFlix.Application.ViewModels
{
    public class EpisodeViewModel : ViewModel
    {
        public int EpisodeNumber { get;  set; }
        public string Title { get;  set; }
        public string Description { get;  set; }
        public string VideoUrl { get;  set; }
        public int Duration { get;  set; }
        public int AnimeId { get; set; }
    }
}
