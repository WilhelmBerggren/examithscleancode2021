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
    static HttpClient client = new HttpClient();
    List<DetailedMovie> DetailedMovies { get; set; }
    public DetailedMovieRepository()
    {
        var jsonResult = client.GetAsync("https://ithstenta2020.s3.eu-north-1.amazonaws.com/detailedMovies.json").Result;
        DetailedMovies = JsonSerializer.Deserialize<List<DetailedMovie>>(new StreamReader(jsonResult.Content.ReadAsStream()).ReadToEnd());
    }
    public IEnumerable<DetailedMovie> GetDetailedMovies()
    {
        return DetailedMovies;
    }
  }
}