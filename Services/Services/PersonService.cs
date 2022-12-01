using CrimeSystem.DTOs;
using CrimeSystem.Models;
using CrimeSystem.Services.Interfaces;
using Dapper;
using Npgsql;

namespace CrimeSystem.Services;

public class PersonService : IPersonService {
    private string createPersonSQL = "";
    private string getPersonByIdSQL = "SELECT * FROM person AS p WHERE p.id = @PersonID";
    private string getAllPersonSQL = "SELECT * FROM person";
    private IConfiguration config;
    public PersonService(IConfiguration config) {
        this.config = config;
    }


    public async Task<Person> CreatePerson(PersonToCreate personToCreate) {
        using var dbConnection = new NpgsqlConnection(this.config["dbConnString"]);

        var crimeID = await dbConnection.ExecuteAsync(this.createPersonSQL, personToCreate);

        return await this.GetPerson(crimeID);
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
