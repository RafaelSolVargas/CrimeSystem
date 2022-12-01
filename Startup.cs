using CrimeSystem.API.Extensions;
using CrimeSystem.API.IoC;

namespace CrimeSystem.API;

public class Startup : Interfaces.IStartupAPI {
    public IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration) =>
        this.Configuration = configuration;

    public void ConfigureServices(IServiceCollection services) {
        services.AddCors();
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddRouting(options => options.LowercaseUrls = true);
        services.RegisterServices(Configuration);
        services.AddHttpContextAccessor();
        services.AddSwagger();
    }

    public void Configure(WebApplication app, IWebHostEnvironment env) {
        app.UseRouting();
        app.UseCors(x => x
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());

        app.MapControllers();
        app.UseEndpoints(endpoints => {
            endpoints.MapControllers();
        });

        app.UseHttpLogging();
        app.UseSwagger();
        app.UseSwaggerUI();
    }
}
