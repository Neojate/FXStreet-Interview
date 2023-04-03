using Football.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Football.API.Jobs
{
    public class AlignementHostedService : IHostedService
    {
        private const int FREEZE_MIN = 5;
        private const string URI = "http://http://interview-api.azurewebsites.net/swagger/index.html";

        private readonly FootballContext footballContext;

        private Timer timer;

        public AlignementHostedService(IServiceProvider serviceProvider)
        {
            footballContext = serviceProvider.CreateScope().ServiceProvider.GetService<FootballContext>();
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            timer = new Timer(Launch, null, TimeSpan.Zero, TimeSpan.FromSeconds(10));

            return Task.CompletedTask;
        }

        public void Launch(object state)
        {
            var results = footballContext.Matches.Where(match => match.Date > DateTime.Now && match.Date.AddMinutes(-5) < DateTime.Now);

            foreach(var match in results)
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(URI);
                //TODO: hacer la petición a la API               
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
