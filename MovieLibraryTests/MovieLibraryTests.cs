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
        
        [TestMethod]
        public void TestGetMovieById() {
            var movies = new[] {
                new Movie { id = "1", title = "a", rated = "5,0"},
                new Movie { id = "2", title = "b", rated = "6,0"}
            };
            var repository = new MockedMovieRepository(movies);
            var controller = new MovieController(repository);

            var expected = movies.First();
            var actual = controller.GetMovieById("1");

            Assert.AreEqual(expected, actual);
        }
        
        [TestMethod]
        public void TestDetailedMovieConversion() 
        {
            var movies = new[] {
                new Movie { id = "1", title = "a", rated = "5,0"},
                new Movie { id = "2", title = "b", rated = "6,0"}
            };
            
            var detailedMovies = new[] {
                new DetailedMovie { id = "3", title = "c", imdbRating = 7.0 },
                new DetailedMovie { id = "4", title = "d", imdbRating = 8.0 }
            };

            var simpleMovieRepository = new MockedSimpleMovieRepository(movies);
            var detailedMovieRepository = new MockedDetailedMovieRepository(detailedMovies);
            var combinedMovieRepository = new MovieRepository(simpleMovieRepository, detailedMovieRepository);

            var expected = new Movie { id = "3", title = "c", rated = "7,0" };
            var actual = combinedMovieRepository.SimplifyDetailedMovie(detailedMovies.First());

            Assert.AreEqual(expected.title, actual.title);
            Assert.AreEqual(expected.rated, actual.rated);
        }
        
        [TestMethod]
        public void TestMovieRepositoryCombined() 
        {
            var movies = new[] {
                new Movie { id = "1", title = "a", rated = "5,0"},
                new Movie { id = "2", title = "b", rated = "6,0"}
            };
            
            var detailedMovies = new[] {
                new DetailedMovie { id = "1", title = "a", imdbRating = 7.0 },
                new DetailedMovie { id = "4", title = "d", imdbRating = 8.0 }
            };

            var simpleMovieRepository = new MockedSimpleMovieRepository(movies);
            var detailedMovieRepository = new MockedDetailedMovieRepository(detailedMovies);
            var combinedMovieRepository = new MovieRepository(simpleMovieRepository, detailedMovieRepository);

            var expected = 3;
            var actual = combinedMovieRepository.GetMovies().Count();
            foreach(var m in combinedMovieRepository.GetMovies()) {
                System.Console.WriteLine(m.id);
                System.Console.WriteLine(m.title);
            }
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(expected, actual);
        }
    }
}
