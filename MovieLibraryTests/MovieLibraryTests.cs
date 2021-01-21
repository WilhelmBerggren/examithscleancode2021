using Microsoft.VisualStudio.TestTools.UnitTesting;
using MovieLibrary.Services;
using MovieLibrary.Controllers;
using MovieLibraryTests.Mocks;

namespace MovieLibraryTests
{
    [TestClass]
    public class MovieLibraryTests
    {
        [TestMethod]
        public void TestMovieController()
        {
            var repository = new MockedMovieRepository();
            var controller = new MovieController(repository);
            repository.GetMovies();
        }
    }
}
