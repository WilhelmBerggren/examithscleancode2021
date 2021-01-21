using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using MovieLibrary.Models;

namespace MovieLibrary.Services
{
    public class SimpleMovieRepository : ISimpleMovieRepository
    {
        static HttpClient client = new HttpClient();
        List<Movie> Movies { get; set; }
        public SimpleMovieRepository()
        {
            var jsonResult = client.GetAsync("https://ithstenta2020.s3.eu-north-1.amazonaws.com/topp100.json").Result;
            Movies = JsonSerializer.Deserialize<List<Movie>>(new StreamReader(jsonResult.Content.ReadAsStream()).ReadToEnd());
        }
        public IEnumerable<Movie> GetMovies()
        {
            return Movies;
        }
    }
}