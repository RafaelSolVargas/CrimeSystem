using CrimeSystem.DTOs;
using CrimeSystem.Models;
using CrimeSystem.Services.Interfaces;
using Dapper;
using Npgsql;

namespace CrimeSystem.Services;

public class CrimeTypeService : ICrimeTypeService {
    private string createCrimeTypeSQL = "";
    private string getCrimeTypeByIdSQL = "SELECT * FROM  AS v WHERE v.id = @VehicleID";
    private string getAllCrimeTypeSQL = "";
    private IConfiguration config;
    public CrimeTypeService(IConfiguration config) {
        this.config = config;
    }


    public async Task<CrimeType> CreateCrimeType(CrimeTypeToCreate CrimeTypeToCreate) {
        using var dbConnection = new NpgsqlConnection(this.config["dbConnString"]);

        var crimeID = await dbConnection.ExecuteAsync(this.createCrimeTypeSQL, CrimeTypeToCreate);

        return await this.GetCrimeType(crimeID);
    }

    public async Task<List<CrimeType>> GetAll() {
        using var dbConnection = new NpgsqlConnection(this.config["dbConnString"]);

        var CrimeTypes = await dbConnection.QueryAsync<CrimeType>(this.getAllCrimeTypeSQL);
        return CrimeTypes.ToList();
    }

    public async Task<CrimeType> GetCrimeType(int CrimeTypeID) {
        using var dbConnection = new NpgsqlConnection(this.config["dbConnString"]);

        var CrimeTypes = await dbConnection.QueryAsync<CrimeType>(this.getCrimeTypeByIdSQL, new { CrimeTypeID = CrimeTypeID });
        return CrimeTypes.First();
    }
}
