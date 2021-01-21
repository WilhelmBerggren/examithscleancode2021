using System.Collections.Generic;
using MovieLibrary.Controllers;
using MovieLibrary.Models;

namespace MovieLibrary.Services {
  public class MovieRepository: IMovieRepository {
    IEnumerable<Movie> IMovieRepository.GetMovies()
    {
      throw new System.NotImplementedException();
    }
  }
}