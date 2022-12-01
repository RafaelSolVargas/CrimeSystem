using CrimeSystem.DTOs;
using CrimeSystem.Models;
using CrimeSystem.Services.Interfaces;
using Dapper;
using Npgsql;

namespace CrimeSystem.Services;

public class CrimeService : ICrimeService {
    private string createCrimeSQL = "";
    private string getCrimeByIdSQL = "";
    private string getAllCrimeSQL = "";
    private IConfiguration config;
    public CrimeService(IConfiguration config) {
        this.config = config;
    }

    public async Task<Crime> CreateCrime(CrimeToCreate crimeToCreate) {
        using var dbConnection = new NpgsqlConnection(this.config["dbConnString"]);

        var crimeID = await dbConnection.ExecuteAsync(this.createCrimeSQL, crimeToCreate);

        return await this.GetCrime(crimeID);
    }

    public async Task<List<Crime>> GetAll() {
        using var dbConnection = new NpgsqlConnection(this.config["dbConnString"]);

        var crimes = await dbConnection.QueryAsync<Crime>(this.getAllCrimeSQL);
        return crimes.ToList();
    }

    public async Task<Crime> GetCrime(int crimeID) {
        using var dbConnection = new NpgsqlConnection(this.config["dbConnString"]);

        var crimes = await dbConnection.QueryAsync<Crime>(this.getCrimeByIdSQL, new { crimeID = crimeID });
        return crimes.First();
    }
}
