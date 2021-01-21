using Microsoft.VisualStudio.TestTools.UnitTesting;
using MovieLibrary.Services;
using MovieLibrary.Models;
using MovieLibrary.Controllers;
using MovieLibraryTests.Mocks;
using System.Linq;

namespace MovieLibraryTests
{
    [TestClass]
    public class MovieLibraryTests
    {
        [TestMethod]
        public void TestMovieController()
        {
            var movies = new[] {
                new Movie { id = "1", title = "a", rated = "5,0"}
            };
            var repository = new MockedMovieRepository(movies);
            var controller = new MovieController(repository);
            Assert.AreEqual(movies, repository.GetMovies());

            var expected = movies.Select(m => m.title).First();
            var actual = controller.Toplist(true).First();
            Assert.AreEqual(actual, expected);
        }
    }
}
