using CrimeSystem.DTOs;
using CrimeSystem.Models;
using CrimeSystem.Services.Interfaces;
using Dapper;
using Npgsql;

namespace CrimeSystem.Services;

public class WeaponService : IWeaponService {
    private string createWeaponSQL = "";
    private string getWeaponByIdSQL = "SELECT * FROM weapon AS w WHERE w.id = @WeaponID";
    private string getAllWeaponSQL = "SELECT * FROM weapon";
    private IConfiguration config;
    public WeaponService(IConfiguration config) {
        this.config = config;
    }


    public async Task<Weapon> CreateWeapon(WeaponToCreate WeaponToCreate) {
        using var dbConnection = new NpgsqlConnection(this.config["dbConnString"]);

        var crimeID = await dbConnection.ExecuteAsync(this.createWeaponSQL, WeaponToCreate);

        return await this.GetWeapon(crimeID);
    }

    public async Task<List<Weapon>> GetAll() {
        using var dbConnection = new NpgsqlConnection(this.config["dbConnString"]);

        var Weapons = await dbConnection.QueryAsync<Weapon>(this.getAllWeaponSQL);
        return Weapons.ToList();
    }

    public async Task<Weapon> GetWeapon(int WeaponID) {
        using var dbConnection = new NpgsqlConnection(this.config["dbConnString"]);

        var Weapons = await dbConnection.QueryAsync<Weapon>(this.getWeaponByIdSQL, new { WeaponID = WeaponID });
        return Weapons.First();
    }
}
