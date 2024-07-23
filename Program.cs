using IHttpClientFactoryUsage.Hosted;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHostedService<Worker>();

builder.Services.AddHttpClient();
var app = builder.Build();


app.Run();