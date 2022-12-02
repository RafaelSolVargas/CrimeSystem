using CrimeSystem.DTOs;
using CrimeSystem.Models;
using CrimeSystem.Services.Interfaces;
using Dapper;
using Npgsql;

namespace CrimeSystem.Services;

public class CrimeService : ICrimeService {
    private string createCrimeSQL = "";
    private string getCrimeByIdSQL = "SELECT * FROM crime AS c WHERE c.id = @CrimeID";
    private string getAllCrimeSQL = "SELECT * FROM crime";
    private string deleteByIdSQL = "DELETE FROM crime WHERE id = @id";
    private string getPersonsCrimesOccurrenceSQL = @"SELECT p.id AS personID, p.name, COUNT(*) as quant
                                                        FROM person AS p
                                                        JOIN Person_Crime AS pc
                                                            ON p.id = pc.personID
                                                        JOIN crime AS c
                                                            ON c.id = pc.crimeID
                                                        JOIN crimeType as ct
                                                            ON ct.id = c.crimeTypeID
                                                        WHERE ct.name in ('Furto', 'Roubo', 'Assalto')
                                                        GROUP BY p.id";

    private string getCrimesWithVehiclesSQL = @"SELECT EXTRACT(year FROM c.date) as year, COUNT(*) as quant
                                                FROM crime AS c
                                                JOIN Crime_Vehicle AS cv
                                                    ON c.id = cv.crimeID
                                                JOIN Vehicle AS v
                                                    ON v.id = cv.vehicleID
                                                JOIN crimeType AS ct
                                                    ON ct.id = c.crimeTypeID
                                                WHERE ct.name = 'Homicídio'
                                                GROUP BY EXTRACT(year FROM c.date)";

    private string getAverageHeightByCrimeType = @"SELECT ct.name AS crimeType, AVG(p.height) AS average
                                                FROM crimeType AS ct
                                                JOIN crime AS c
                                                    ON ct.id = c.crimeTypeID
                                                JOIN Person_Crime AS pc
                                                    ON pc.crimeID = c.id
                                                JOIN person AS p
                                                    ON p.id = pc.personID
                                                GROUP BY ct.name;
                                                ";

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

    public async Task<bool> Delete(int id) {
        using var dbConnection = new NpgsqlConnection(this.config["dbConnString"]);

        var deleted = await dbConnection.ExecuteAsync(this.deleteByIdSQL, new { id = id });
        if (deleted > 0)
            return true;
        return false;
    }

    public async Task<Crime> GetCrime(int crimeID) {
        using var dbConnection = new NpgsqlConnection(this.config["dbConnString"]);

        var crimes = await dbConnection.QueryAsync<Crime>(this.getCrimeByIdSQL, new { crimeID = crimeID });
        return crimes.First();
    }

    public async Task<List<CrimeByPersonReport>> GetPersonsCrimesOccurrencesReport() {
        using var dbConnection = new NpgsqlConnection(this.config["dbConnString"]);

        var reports = await dbConnection.QueryAsync<CrimeByPersonReport>(this.getPersonsCrimesOccurrenceSQL);
        return reports.ToList();
    }

    public async Task<List<CrimesWithVehiclesReport>> GetCrimesWithVehicleReports() {
        using var dbConnection = new NpgsqlConnection(this.config["dbConnString"]);

        var reports = await dbConnection.QueryAsync<CrimesWithVehiclesReport>(this.getCrimesWithVehiclesSQL);
        return reports.ToList();
    }

    public async Task<List<AverageHeightByCrimeTypeReport>> GetAverageHeightReport() {
        using var dbConnection = new NpgsqlConnection(this.config["dbConnString"]);

        var reports = await dbConnection.QueryAsync<AverageHeightByCrimeTypeReport>(this.getAverageHeightByCrimeType);
        return reports.ToList();
    }
}
