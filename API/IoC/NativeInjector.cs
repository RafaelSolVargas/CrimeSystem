using CrimeSystem.Services;
using CrimeSystem.Services.Interfaces;

namespace CrimeSystem.API.IoC;


public static class NativeInjector {
    public static void RegisterServices(this IServiceCollection services, IConfiguration configuration) {
        // Services
        services.AddScoped<ICrimeService, CrimeService>();
        services.AddScoped<IVehicleService, VehicleService>();
        services.AddScoped<IWeaponService, WeaponService>();
        services.AddScoped<IPersonService, PersonService>();
        services.AddScoped<ICrimeTypeService, CrimeTypeService>();
        services.AddScoped<ICrimePhotoService, CrimePhotoService>();
        services.AddScoped<ICharacteristicService, CharacteristicService>();
    }
}

