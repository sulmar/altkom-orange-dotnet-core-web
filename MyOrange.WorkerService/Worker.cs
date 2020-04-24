using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MyOrange.Fakers;

namespace MyOrange.WorkerService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;

        const string url = "http://localhost:5000/signalr/customers";

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            CustomerFaker customerFaker = new CustomerFaker();

            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

                // dotnet add package Microsoft.AspNetCore.SignalR.Client
                HubConnection connection = new HubConnectionBuilder()
                    .WithUrl(url)
                    .Build();

                _logger.LogInformation("Connecting...");

                await connection.StartAsync();

                _logger.LogInformation("Connected.");
              
                await connection.SendAsync("CreatedCustomer", customerFaker.Generate());

                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
