using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;

namespace IHttpClientFactoryUsage.Hosted;

public class Worker([FromServices]IHttpClientFactory factory):BackgroundService
{
    private static readonly TimeSpan IntervalMilliSeconds = new(0, 0, 0, 2, 0);
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            var client=factory.CreateClient();
            await client.GetAsync(new Uri(""),stoppingToken);
            await Task.Delay(IntervalMilliSeconds, stoppingToken);
        }
    }
}