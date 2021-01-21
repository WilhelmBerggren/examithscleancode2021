using Microsoft.VisualStudio.TestTools.UnitTesting;
using MovieLibrary.Services;
using MovieLibrary.Controllers;

namespace MovieLibraryTests
{
    [TestClass]
    public class MovieLibraryTests
    {
        [TestMethod]
        public void TestMovieRepository()
        {
            var repository = new MovieRepository();
            repository.GetMovies();
        }
    }
}
