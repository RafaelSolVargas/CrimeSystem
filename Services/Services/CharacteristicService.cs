using CrimeSystem.DTOs;
using CrimeSystem.Models;
using CrimeSystem.Services.Interfaces;
using Dapper;
using Npgsql;

namespace CrimeSystem.Services;

public class CharacteristicService : ICharacteristicService {
    private string createCharacteristicSQL = "INSERT INTO characteristic (description) VALUES (@description) RETURNING id";
    private string getCharacteristicByIdSQL = "SELECT * FROM characteristic AS c WHERE c.id = @CharacteristicID";
    private string getAllCharacteristicSQL = "SELECT * FROM characteristic";
    private string deleteByIdSQL = "DELETE FROM characteristic WHERE id = @id";
    private IConfiguration config;
    public CharacteristicService(IConfiguration config) {
        this.config = config;
    }


    public async Task<Characteristic> CreateCharacteristic(CharacteristicToCreate CharacteristicToCreate) {
        using var dbConnection = new NpgsqlConnection(this.config["dbConnString"]);

        var crimeID = await dbConnection.ExecuteAsync(this.createCharacteristicSQL, CharacteristicToCreate);

        return await this.GetCharacteristic(crimeID);
    }

    public async Task<bool> Delete(int id) {
        using var dbConnection = new NpgsqlConnection(this.config["dbConnString"]);

        var deleted = await dbConnection.ExecuteAsync(this.deleteByIdSQL, new { id = id });
        if (deleted > 0)
            return true;
        return false;
    }

    public async Task<List<Characteristic>> GetAll() {
        using var dbConnection = new NpgsqlConnection(this.config["dbConnString"]);

        var Characteristics = await dbConnection.QueryAsync<Characteristic>(this.getAllCharacteristicSQL);
        return Characteristics.ToList();
    }

    public async Task<Characteristic> GetCharacteristic(int CharacteristicID) {
        using var dbConnection = new NpgsqlConnection(this.config["dbConnString"]);

        var Characteristics = await dbConnection.QueryAsync<Characteristic>(this.getCharacteristicByIdSQL, new { CharacteristicID = CharacteristicID });
        return Characteristics.First();
    }
}
