namespace CrimeSystem.API.Interfaces;
public interface IStartupAPI {
    IConfiguration Configuration { get; }

    void ConfigureServices(IServiceCollection services);

    void Configure(WebApplication app, IWebHostEnvironment env);
}
