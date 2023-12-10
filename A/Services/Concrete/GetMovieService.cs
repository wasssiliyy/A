using A.Entities;
using A.Services.Abatract;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace A.Services.Concrete
{
    public class GetMovieService : IGetMovieService
    {
        private readonly IMovieService _movieService;

        public GetMovieService(IMovieService movieService)
        {
            _movieService = movieService;
        }

        public static dynamic SingleData { get; set; }
        public static dynamic Data { get; set; }

        public async Task<IEnumerable<Movie>> GetAllMovies()
        {
            return await _movieService.GetAll();
        }

        public async Task Get()
        {
            List<string> strAlpha = new List<string>();

            for (int i = 65; i <= 90; i++)
            {
                strAlpha.Add(((char)i).ToString());
            }

            List<Movie> movies = new List<Movie>();
            var allMovies = await _movieService.GetAll();
            movies = allMovies.ToList();

            var random = RandomNumber(0, strAlpha.Count);
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response = new HttpResponseMessage();
            response = await httpClient.GetAsync($@"http://www.omdbapi.com/?apikey=ab88e99a&t={strAlpha[random]}&plot=full");
            var str = await response.Content.ReadAsStringAsync();
            SingleData = JsonConvert.DeserializeObject(str);
            Data = JsonConvert.DeserializeObject(str);

            var myMovie = new Movie();

            var ImdbRating = (SingleData.imdbRating).ToString().Replace("{", "");
            myMovie.ImdbRating = double.Parse(ImdbRating.Replace("}", "").Trim());
            myMovie.Genre = SingleData.Genre;
            myMovie.Title = SingleData.Title;
            myMovie.Director = SingleData.Director;

            var movieUnique = movies.FirstOrDefault(o => o.Title == myMovie.Title);
            if (movieUnique == null)
            {
                await _movieService.Add(myMovie);
            }
        }

        public static int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }
    }
}
