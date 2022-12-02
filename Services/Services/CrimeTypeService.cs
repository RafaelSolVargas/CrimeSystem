using CrimeSystem.DTOs;
using CrimeSystem.Models;
using CrimeSystem.Services.Interfaces;
using Dapper;
using Npgsql;

namespace CrimeSystem.Services;

public class CrimeTypeService : ICrimeTypeService {
    private string createCrimeTypeSQL = "INSERT INTO crimeType (name) VALUES (@name) RETURNING id";
    private string getCrimeTypeByIdSQL = "SELECT * FROM  crimeType AS ct WHERE ct.id = @CrimeTypeID";
    private string getAllCrimeTypeSQL = "SELECT * FROM crimeType";
    private string deleteByIdSQL = "DELETE FROM crimeType WHERE id = @id";

    private IConfiguration config;
    public CrimeTypeService(IConfiguration config) {
        this.config = config;
    }


    public async Task<CrimeType> CreateCrimeType(CrimeTypeToCreate CrimeTypeToCreate) {
        using var dbConnection = new NpgsqlConnection(this.config["dbConnString"]);

        var crimeID = await dbConnection.ExecuteAsync(this.createCrimeTypeSQL, CrimeTypeToCreate);

        return await this.GetCrimeType(crimeID);
    }
    public async Task<bool> Delete(int id) {
        using var dbConnection = new NpgsqlConnection(this.config["dbConnString"]);

        var deleted = await dbConnection.ExecuteAsync(this.deleteByIdSQL, new { id = id });
        if (deleted > 0)
            return true;
        return false;
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
