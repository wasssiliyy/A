using A.Controllers;
using A.Data;
using A.Repositories.Abstract;
using A.Services.Abatract;
using System.Threading;

namespace A.Services.Concrete
{

    public class BackgroundWorkerService : BackgroundService
    {
        private IServiceProvider _serviceProvider;
        private readonly IGetMovieService _getMovieService;
        private readonly ILogger<BackgroundWorkerService> _logger;
        private readonly IConfiguration _configuration;
        //private readonly MoviewDbContext _F;
        //private readonly IMovieRepository _movieRepository;
        //private readonly IMovieService _movieService;

        public BackgroundWorkerService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;

            try
            {
                var scope = _serviceProvider.CreateScope();
                //_movieRepository = scope.ServiceProvider.GetRequiredService<IMovieRepository>();
                _getMovieService = scope.ServiceProvider.GetRequiredService<IGetMovieService>();
                _logger = scope.ServiceProvider.GetRequiredService<ILogger<BackgroundWorkerService>>();
                _configuration = scope.ServiceProvider.GetRequiredService<IConfiguration>();
                //_F = scope.ServiceProvider.GetRequiredService<MoviewDbContext>();
                //_movieService = scope.ServiceProvider.GetRequiredService<IMovieService>();
            }
            catch (Exception)
            {
                throw;
            }
        }


        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var minute = int.Parse(_configuration["Time:minute"]);
                _logger.LogInformation("Worker running at : {time}", DateTimeOffset.Now);
                await Task.Delay(minute * 1000, stoppingToken);

                await _getMovieService.Get();
            }
        }
    }
}