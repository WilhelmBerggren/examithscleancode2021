using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using MovieLibrary.Models;

namespace MovieLibrary.Services
{
    public class SimpleMovieRepository : ISimpleMovieRepository
    {
        const string dataUrl = "https://ithstenta2020.s3.eu-north-1.amazonaws.com/topp100.json";
        static HttpClient client = new HttpClient();
        public IEnumerable<Movie> GetMovies()
        {
            var httpResult = client.GetAsync(dataUrl).Result;
            var jsonResult = new StreamReader(httpResult.Content.ReadAsStream()).ReadToEnd();
            return JsonSerializer.Deserialize<List<Movie>>(jsonResult);
        }
    }
}