using CrimeSystem.DTOs;
using CrimeSystem.Models;
using CrimeSystem.Services.Interfaces;
using Dapper;
using Npgsql;

namespace CrimeSystem.Services;

public class VehicleService : IVehicleService {
    private string createVehicleSQL = "INSERT INTO vehicle (type, plateNumber, model) VALUES (@type, @plateNumber, @model) RETURNING id";
    private string getVehicleByIdSQL = "SELECT * FROM vehicle AS v WHERE v.id = @VehicleID";
    private string getAllVehicleSQL = "SELECT * FROM vehicle";
    private string deleteByIdSQL = "DELETE FROM vehicle WHERE id = @id";

    private IConfiguration config;
    public VehicleService(IConfiguration config) {
        this.config = config;
    }


    public async Task<Vehicle> CreateVehicle(VehicleToCreate VehicleToCreate) {
        using var dbConnection = new NpgsqlConnection(this.config["dbConnString"]);

        var vehicleID = (await dbConnection.QueryAsync<int>(this.createVehicleSQL, new {
            type = VehicleToCreate.type,
            plateNumber = VehicleToCreate.plateNumber,
            model = VehicleToCreate.model
        })).First();

        return await this.GetVehicle(vehicleID);
    }

    public async Task<List<Vehicle>> GetAll() {
        using var dbConnection = new NpgsqlConnection(this.config["dbConnString"]);

        var Vehicles = await dbConnection.QueryAsync<Vehicle>(this.getAllVehicleSQL);
        return Vehicles.ToList();
    }

    public async Task<bool> Delete(int id) {
        using var dbConnection = new NpgsqlConnection(this.config["dbConnString"]);

        var deleted = await dbConnection.ExecuteAsync(this.deleteByIdSQL, new { id = id });
        if (deleted > 0)
            return true;
        return false;
    }

    public async Task<Vehicle> GetVehicle(int VehicleID) {
        using var dbConnection = new NpgsqlConnection(this.config["dbConnString"]);

        var Vehicles = await dbConnection.QueryAsync<Vehicle>(this.getVehicleByIdSQL, new { VehicleID = VehicleID });
        return Vehicles.First();
    }
}
