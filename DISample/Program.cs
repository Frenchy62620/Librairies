using DISample;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting; // Requires NuGet package

//var host = Host.CreateDefaultBuilder(args)
//    .ConfigureServices(services => { services.AddTransient<MyService>(); })
//    .Build();

var host = Host.CreateDefaultBuilder()
               .ConfigureServices((context, services) =>
{
    services.AddSingleton<ITemperatureSensor, AcmeTemperatureSensor>();
    services.AddSingleton<IAcmeMachine, AcmeMachine>();
    services.AddTransient<AcmeMachine>();
    //services.Configure<TemperatureSensorOptions>(context.Configuration.GetSection(nameof(TemperatureSensorOptions)));
}).Build();

//var my = host.Services.GetRequiredService<MyService>();
var my = host.Services.GetRequiredService<AcmeMachine>();
//await my.ExecuteAsync();

//class MyService
//{
//    private readonly ILogger<MyService> _logger;

//    public MyService(ILogger<MyService> logger)
//    {
//        _logger = logger;
//    }

//    public async Task ExecuteAsync(CancellationToken stoppingToken = default)
//    {
//        _logger.LogInformation("Doing something");
//    }
//}