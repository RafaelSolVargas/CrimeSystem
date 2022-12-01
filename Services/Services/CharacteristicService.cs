using CrimeSystem.DTOs;
using CrimeSystem.Models;
using CrimeSystem.Services.Interfaces;
using Dapper;
using Npgsql;

namespace CrimeSystem.Services;

public class CharacteristicService : ICharacteristicService {
    private string createCharacteristicSQL = "";
    private string getCharacteristicByIdSQL = "";
    private string getAllCharacteristicSQL = "";
    private IConfiguration config;
    public CharacteristicService(IConfiguration config) {
        this.config = config;
    }


    public async Task<Characteristic> CreateCharacteristic(CharacteristicToCreate CharacteristicToCreate) {
        using var dbConnection = new NpgsqlConnection(this.config["dbConnString"]);

        var crimeID = await dbConnection.ExecuteAsync(this.createCharacteristicSQL, CharacteristicToCreate);

        return await this.GetCharacteristic(crimeID);
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
