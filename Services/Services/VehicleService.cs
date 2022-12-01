using CrimeSystem.DTOs;
using CrimeSystem.Models;
using CrimeSystem.Services.Interfaces;
using Dapper;
using Npgsql;

namespace CrimeSystem.Services;

public class VehicleService : IVehicleService {
    private string createVehicleSQL = "";
    private string getVehicleByIdSQL = "SELECT * FROM vehicle AS v WHERE v.id = @VehicleID";
    private string getAllVehicleSQL = "SELECT * FROM vehicle";
    private IConfiguration config;
    public VehicleService(IConfiguration config) {
        this.config = config;
    }


    public async Task<Vehicle> CreateVehicle(VehicleToCreate VehicleToCreate) {
        using var dbConnection = new NpgsqlConnection(this.config["dbConnString"]);

        var crimeID = await dbConnection.ExecuteAsync(this.createVehicleSQL, VehicleToCreate);

        return await this.GetVehicle(crimeID);
    }

    public async Task<List<Vehicle>> GetAll() {
        using var dbConnection = new NpgsqlConnection(this.config["dbConnString"]);

        var Vehicles = await dbConnection.QueryAsync<Vehicle>(this.getAllVehicleSQL);
        return Vehicles.ToList();
    }

    public async Task<Vehicle> GetVehicle(int VehicleID) {
        using var dbConnection = new NpgsqlConnection(this.config["dbConnString"]);

        var Vehicles = await dbConnection.QueryAsync<Vehicle>(this.getVehicleByIdSQL, new { VehicleID = VehicleID });
        return Vehicles.First();
    }
}
