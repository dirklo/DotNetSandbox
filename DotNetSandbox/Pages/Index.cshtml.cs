using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace DotNetSandbox.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IMovieService _movieService;

        public IndexModel(IMovieService movieSvc) {
            _movieService = movieSvc;
        }

        public IList<Movie> Movies
        {
            get;
            set;
        }

        public async Task OnGet()
        {
            Movies = await _movieService.GetMovies();
        }
    }
}
