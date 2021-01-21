using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using MovieLibrary.Models;

namespace MovieLibrary.Services
{
    public class DetailedMovieRepository : IDetailedMovieRepository
    {
        const string dataUrl = "https://ithstenta2020.s3.eu-north-1.amazonaws.com/detailedMovies.json";
        static HttpClient client = new HttpClient();
        List<DetailedMovie> DetailedMovies { get; set; }
        public IEnumerable<DetailedMovie> GetDetailedMovies()
        {
            var httpResult = client.GetAsync(dataUrl).Result;
            var jsonResult = new StreamReader(httpResult.Content.ReadAsStream()).ReadToEnd();
            return JsonSerializer.Deserialize<List<DetailedMovie>>(jsonResult);
        }
    }
}