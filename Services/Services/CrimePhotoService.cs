using CrimeSystem.DTOs;
using CrimeSystem.Models;
using CrimeSystem.Services.Interfaces;
using Dapper;
using Npgsql;

namespace CrimeSystem.Services;

public class CrimePhotoService : ICrimePhotoService {
    private string createCrimePhotoSQL = "INSERT INTO crimePhoto (photo, description) VALUES (@photo, @description) RETURNING id";
    private string getCrimePhotoByIdSQL = "SELECT * FROM crimePhoto AS cp WHERE cp.id = @CrimePhotoID";
    private string getAllCrimePhotoSQL = "SELECT * FROM crimePhoto";
    private string deleteByIdSQL = "DELETE FROM crimePhoto WHERE id = @id";

    private IConfiguration config;
    public CrimePhotoService(IConfiguration config) {
        this.config = config;
    }


    public async Task<CrimePhoto> CreateCrimePhoto(CrimePhotoToCreate CrimePhotoToCreate) {
        using var dbConnection = new NpgsqlConnection(this.config["dbConnString"]);

        var crimeID = await dbConnection.ExecuteAsync(this.createCrimePhotoSQL, CrimePhotoToCreate);

        return await this.GetCrimePhoto(crimeID);
    }

    public async Task<List<CrimePhoto>> GetAll() {
        using var dbConnection = new NpgsqlConnection(this.config["dbConnString"]);

        var CrimePhotos = await dbConnection.QueryAsync<CrimePhoto>(this.getAllCrimePhotoSQL);
        return CrimePhotos.ToList();
    }

    public async Task<bool> Delete(int id) {
        using var dbConnection = new NpgsqlConnection(this.config["dbConnString"]);

        var deleted = await dbConnection.ExecuteAsync(this.deleteByIdSQL, new { id = id });
        if (deleted > 0)
            return true;
        return false;
    }

    public async Task<CrimePhoto> GetCrimePhoto(int CrimePhotoID) {
        using var dbConnection = new NpgsqlConnection(this.config["dbConnString"]);

        var CrimePhotos = await dbConnection.QueryAsync<CrimePhoto>(this.getCrimePhotoByIdSQL, new { CrimePhotoID = CrimePhotoID });
        return CrimePhotos.First();
    }
}
