using CrimeSystem.DTOs;
using CrimeSystem.Models;
using CrimeSystem.Services.Interfaces;
using Dapper;
using Npgsql;

namespace CrimeSystem.Services;

public class CrimePhotoService : ICrimePhotoService {
    private string createCrimePhotoSQL = "";
    private string getCrimePhotoByIdSQL = "";
    private string getAllCrimePhotoSQL = "";
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

    public async Task<CrimePhoto> GetCrimePhoto(int CrimePhotoID) {
        using var dbConnection = new NpgsqlConnection(this.config["dbConnString"]);

        var CrimePhotos = await dbConnection.QueryAsync<CrimePhoto>(this.getCrimePhotoByIdSQL, new { CrimePhotoID = CrimePhotoID });
        return CrimePhotos.First();
    }
}
