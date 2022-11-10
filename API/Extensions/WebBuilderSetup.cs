using CrimeSystem.API.Interfaces;

namespace CrimeSystem.API.Extensions;

public static class WebApplicationBuilderExtensions {
    public static WebApplicationBuilder UseStartup<TStartup>(this WebApplicationBuilder builder) where TStartup : IStartupAPI {
        var startup = Activator.CreateInstance(typeof(TStartup), builder.Configuration) as IStartupAPI;
        if (startup == null)
            throw new ArgumentException("Startup class is invalid.");

        startup.ConfigureServices(builder.Services);
        var app = builder.Build();

        startup.Configure(app, app.Environment);
        app.Run();

        return builder;
    }
}
