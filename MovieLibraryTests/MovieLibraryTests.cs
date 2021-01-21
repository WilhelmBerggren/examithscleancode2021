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

        [TestMethod]
        public void TestTopListAscending()
        {
            var movies = new[] {
                new Movie { id = "1", title = "a", rated = "5,0"},
                new Movie { id = "2", title = "b", rated = "6,0"}
            };
            var repository = new MockedMovieRepository(movies);
            var controller = new MovieController(repository);

            var expected = controller.Toplist(true);
            var actual = movies.OrderBy(m => m.rated).Select(m => m.title);

            Assert.AreEqual(expected.First(), actual.First());
            Assert.AreEqual(actual.First(), "a");
        }
        
        [TestMethod]
        public void TestTopListDescending()
        {
            var movies = new[] {
                new Movie { id = "1", title = "a", rated = "5,0"},
                new Movie { id = "2", title = "b", rated = "6,0"}
            };
            var repository = new MockedMovieRepository(movies);
            var controller = new MovieController(repository);

            var expected = controller.Toplist(false);
            var actual = movies.OrderByDescending(m => m.rated).Select(m => m.title);

            Assert.AreEqual(expected.First(), actual.First());
            Assert.AreEqual(actual.First(), "b");
        }
    }
}
