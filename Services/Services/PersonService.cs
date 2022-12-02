using CrimeSystem.DTOs;
using CrimeSystem.Models;
using CrimeSystem.Services.Interfaces;
using Dapper;
using Npgsql;

namespace CrimeSystem.Services;

public class PersonService : IPersonService {
    private string createPersonSQL = "INSERT INTO person (motherName, fatherName, name, rg, dateBirth, cpf, height) VALUES (@motherName, @fatherName, @name, @rg, @dateBirth, @cpf, @height) RETURNING id";
    private string getPersonByIdSQL = "SELECT * FROM person AS p WHERE p.id = @PersonID";
    private string getAllPersonSQL = "SELECT * FROM person";
    private string deleteByIdSQL = "DELETE FROM person WHERE id = @id";

    private IConfiguration config;
    public PersonService(IConfiguration config) {
        this.config = config;
    }


    public async Task<Person> CreatePerson(PersonToCreate personToCreate) {
        using var dbConnection = new NpgsqlConnection(this.config["dbConnString"]);
        Console.WriteLine("Add Person");

        var personID = (await dbConnection.QueryAsync<int>(this.createPersonSQL, new {
            motherName = personToCreate.motherName,
            fatherName = personToCreate.fatherName,
            name = personToCreate.name,
            rg = personToCreate.rg,
            dateBirth = personToCreate.dateBirth,
            cpf = personToCreate.cpf,
            height = personToCreate.height
        })).First();

        return await this.GetPerson(personID);
    }
    public async Task<bool> Delete(int id) {
        using var dbConnection = new NpgsqlConnection(this.config["dbConnString"]);

        var deleted = await dbConnection.ExecuteAsync(this.deleteByIdSQL, new { id = id });
        if (deleted > 0)
            return true;
        return false;
    }

    public async Task<List<Person>> GetAll() {
        using var dbConnection = new NpgsqlConnection(this.config["dbConnString"]);

        var persons = await dbConnection.QueryAsync<Person>(this.getAllPersonSQL);
        return persons.ToList();
    }

    public async Task<Person> GetPerson(int personID) {
        using var dbConnection = new NpgsqlConnection(this.config["dbConnString"]);

        var persons = await dbConnection.QueryAsync<Person>(this.getPersonByIdSQL, new { personID = personID });
        return persons.First();
    }
}
