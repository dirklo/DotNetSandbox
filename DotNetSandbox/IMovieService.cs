using System.Collections.Generic;
using System.Threading.Tasks;

namespace DotNetSandbox
{
    public interface IMovieService
    {
        Task<IList<Movie>> GetMovies();
        IList<Movie> GetMoviesFrom(string content);
    }
}