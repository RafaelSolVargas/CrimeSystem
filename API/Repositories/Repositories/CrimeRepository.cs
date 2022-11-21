using CrimeSystem.Repositories.Interfaces;
using CrimeSystem.Models;
using CrimeSystem.DTOs;
using Npgsql;
using Dapper;

namespace CrimeSystem.Repositories;

public class CrimeRepository : ICrimeRepository {
    private string createCrimeQuery = "";
    private IConfiguration config;
    private NpgsqlConnection dbConnection;

    public CrimeRepository(IConfiguration config) {
        this.config = config;
        this.dbConnection = new NpgsqlConnection(this.config["dbConnString"]);
    }

    public async Task<Crime> CreateCrime(CrimeToCreate crimeToCreate) {
        var crime = await this.dbConnection.QueryAsync<Crime>(this.createCrimeQuery);
        return crime.First();
    }

    public Task<List<Crime>> GetAll() {
        throw new NotImplementedException();
    }

    public Task<Crime> GetCrime(int crimeID) {
        throw new NotImplementedException();
    }
}
