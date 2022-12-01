using CrimeSystem.DTOs;
using CrimeSystem.Models;

namespace CrimeSystem.Services.Interfaces {
    public interface IVehicleService {
        Task<Vehicle> CreateVehicle(VehicleToCreate vehicleToCreate);
        Task<Vehicle> GetVehicle(int vehicleID);
        Task<List<Vehicle>> GetAll();
    }
}
