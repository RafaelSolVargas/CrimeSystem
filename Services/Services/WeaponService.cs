using CrimeSystem.DTOs;
using CrimeSystem.Models;
using CrimeSystem.Services.Interfaces;
using Dapper;
using Npgsql;

namespace CrimeSystem.Services;

public class WeaponService : IWeaponService {
    private string createWeaponSQL = "INSERT INTO weapon (type, register, description) VALUES (@type, @register, @description) RETURNING id";
    private string getWeaponByIdSQL = "SELECT * FROM weapon AS w WHERE w.id = @WeaponID";
    private string getAllWeaponSQL = "SELECT * FROM weapon";
    private string deleteByIdSQL = "DELETE FROM weapon WHERE id = @id";

    private IConfiguration config;
    public WeaponService(IConfiguration config) {
        this.config = config;
    }


    public async Task<Weapon> CreateWeapon(WeaponToCreate WeaponToCreate) {
        using var dbConnection = new NpgsqlConnection(this.config["dbConnString"]);

        var weaponID = (await dbConnection.QueryAsync<int>(this.createWeaponSQL, new {
            type = WeaponToCreate.type,
            register = WeaponToCreate.register,
            description = WeaponToCreate.description
        })).First();

        return await this.GetWeapon(weaponID);
    }

    public async Task<List<Weapon>> GetAll() {
        using var dbConnection = new NpgsqlConnection(this.config["dbConnString"]);

        var Weapons = await dbConnection.QueryAsync<Weapon>(this.getAllWeaponSQL);
        return Weapons.ToList();
    }

    public async Task<bool> Delete(int id) {
        using var dbConnection = new NpgsqlConnection(this.config["dbConnString"]);

        var deleted = await dbConnection.ExecuteAsync(this.deleteByIdSQL, new { id = id });
        if (deleted > 0)
            return true;
        return false;
    }

    public async Task<Weapon> GetWeapon(int WeaponID) {
        using var dbConnection = new NpgsqlConnection(this.config["dbConnString"]);

        var Weapons = await dbConnection.QueryAsync<Weapon>(this.getWeaponByIdSQL, new { WeaponID = WeaponID });
        return Weapons.First();
    }
}
