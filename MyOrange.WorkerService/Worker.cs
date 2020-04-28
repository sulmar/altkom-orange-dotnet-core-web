using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MyOrange.Fakers;
using MyOrange.Models;

namespace MyOrange.WorkerService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;

        const string url = "http://localhost:5000/signalr/customers";

        CustomerFaker customerFaker = new CustomerFaker();

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {

            // dotnet add package Microsoft.AspNetCore.SignalR.Client
            HubConnection connection = new HubConnectionBuilder()
                .WithUrl(url)
                .Build();

            _logger.LogInformation("Connecting...");

            await connection.StartAsync();

            _logger.LogInformation("Connected.");

           connection.On<Customer>("Created", customer => _logger.LogInformation($"Received {customer.FirstName}"));

            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

                var customer = customerFaker.Generate();

                _logger.LogInformation("Sending {customer} at: {time}", customer.FullName, DateTimeOffset.Now);

                await connection.SendAsync("CreatedCustomer", customer);

                _logger.LogInformation("Sent {customer} at: {time}", customer.FullName, DateTimeOffset.Now);

                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
