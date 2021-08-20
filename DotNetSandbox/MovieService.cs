using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;

namespace DotNetSandbox {

    public class MovieService : IMovieService
    {
        const string MoviesUrl = "https://swapi.dev/api/films/";
        private readonly HttpClient _httpClient;
        private IList<Movie> _movies;

        public MovieService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<IList<Movie>> GetMovies()
        {
            if (_movies == null || _movies.Count <= 0)
            {
                var movieStr = await _httpClient.GetStringAsync(MoviesUrl);
                try
                {
                    _movies = GetMoviesFrom(movieStr);
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine($"error: {ex.ToString()}");
                }
            }

            return _movies;
        }

        public IList<Movie> GetMoviesFrom(string content)
        {
            var data = JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(content);

            var results = new List<Movie>();

            foreach (var movie in data["results"])
            {
                results.Add(new Movie
                {
                    EpisodeId = movie.episode_id,
                    Title = movie.title,
                    Director = movie.director,
                    ReleaseDate = movie.release_date
                });
            };

            return results;
        }
    }
}