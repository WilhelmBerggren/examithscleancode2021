namespace MovieLibrary.Models
{
    public class DetailedMovie
    {
        public string id { get; set; }
        public string title { get; set; }
        public string year { get; set; }
        public string[] genres { get; set; }
        public string[] ratings { get; set; }
        public string poster { get; set; }
        public string contentRating { get; set; }
        public string duration { get; set; }
        public string releaseDate { get; set; }
        public string averageRating { get; set; }
        public string originalTitle { get; set; }
        public string storyline { get; set; }
        public string[] actors { get; set; }
        public string imdbRating { get; set; }
        public string posterUrl { get; set; }
    }
}