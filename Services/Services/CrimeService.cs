using CrimeSystem.DTOs;
using CrimeSystem.Models;
using CrimeSystem.Services.Interfaces;
using Dapper;
using Npgsql;

namespace CrimeSystem.Services;

public class CrimeService : ICrimeService {
    private string getCrimeByIdSQL = "SELECT * FROM crime AS c WHERE c.id = @crimeID";
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

    private string createCrimeSQL = "INSERT INTO Crime (date, crimeTypeID) VALUES (@date, @crimeTypeID) RETURNING id";

    private string addPersonToCrime = "INSERT INTO Person_Crimes (personID, crimeID) VALUES (@personID, @crimeID)";
    private string addWeaponToCrime = "INSERT INTO Crime_Weapon (weaponID, crimeID) VALUES (@weaponID, @crimeID)";
    private string addVehicleToCrime = "INSERT INTO Person_Crimes (vehicleID, crimeID) VALUES (@vehicleID, @crimeID)";

    private string getAllVehiclesCrime = @"SELECT * FROM Crime AS c
                                        JOIN Crime_Vehicle AS cv
                                            ON cv.crimeID = c.id
                                        JOIN Vehicle AS v
                                            ON cv.vehicleID = v.id
                                        WHERE c.id = @crimeID";

    private string getAllPersonsCrime = @"SELECT * FROM Crime AS c
                                        JOIN Person_Crime AS pc
                                        ON pc.crimeID = c.id
                                    JOIN Person AS p
                                        ON pc.personID = p.id
                                        WHERE c.id = @crimeID";

    private string getAllWeaponsCrime = @"SELECT * FROM Crime AS c
                                        JOIN Crime_Weapon AS cw
                                            ON cw.crimeID = c.id
                                        JOIN Weapon AS w
                                            ON cw.weaponID = w.id
                                        WHERE c.id = @crimeID";

    private IConfiguration config;
    private IPersonService personService;
    private IWeaponService weaponService;
    private IVehicleService vehicleService;
    public CrimeService(IConfiguration config, IPersonService personService, IVehicleService vehicleService, IWeaponService weaponService) {
        this.config = config;
        this.personService = personService;
        this.weaponService = weaponService;
        this.vehicleService = vehicleService;
    }

    public async Task<Crime> CreateCrime(CrimeToCreate crimeToCreate) {
        using var dbConnection = new NpgsqlConnection(this.config["dbConnString"]);
        dbConnection.Open();

        using (var transaction = dbConnection.BeginTransaction()) {
            var crimeID = await dbConnection.ExecuteAsync(this.createCrimeSQL, new { date = crimeToCreate.date, crimeTypeID = crimeToCreate.crimeTypeID });
            // Persons
            foreach (var person in crimeToCreate.persons) {
                if (person.alreadyExists)
                    await dbConnection.ExecuteAsync(this.addPersonToCrime, new { crimeID = crimeID, personID = person.id });
                else
                    await this.personService.CreatePerson(person);
            }
            // Vehicle
            foreach (var vehicle in crimeToCreate.vehicles) {
                if (vehicle.alreadyExists)
                    await dbConnection.ExecuteAsync(this.addVehicleToCrime, new { crimeID = crimeID, vehicleID = vehicle.id });
                else
                    await this.vehicleService.CreateVehicle(vehicle);
            }
            // Weapon
            foreach (var weapon in crimeToCreate.weapons) {
                if (weapon.alreadyExists)
                    await dbConnection.ExecuteAsync(this.addWeaponToCrime, new { crimeID = crimeID, weaponID = weapon.id });
                else
                    await this.weaponService.CreateWeapon(weapon);
            }

            transaction.Commit();
            return await this.GetCrime(crimeID);
        }
    }

    public async Task<List<Crime>> GetAll() {
        using var dbConnection = new NpgsqlConnection(this.config["dbConnString"]);

        var crimes = (await dbConnection.QueryAsync<Crime>(this.getAllCrimeSQL)).ToList();

        var crimesList = new List<Crime>();
        foreach (var crime in crimes) {
            crimesList.Add(await this.GetCrime(crime.id));
        }

        return crimesList;
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
        var crime = crimes.First();

        crime.crimeType = (await dbConnection.QueryAsync<CrimeType>("SELECT * FROM CrimeType AS ct WHERE ct.id = @crimeTypeID", new { crimeTypeID = crime.crimeTypeID })).First();

        crime.persons = (await dbConnection.QueryAsync<Person>(this.getAllPersonsCrime, new { crimeID = crimeID })).ToList();
        crime.weapons = (await dbConnection.QueryAsync<Weapon>(this.getAllWeaponsCrime, new { crimeID = crimeID })).ToList();
        crime.vehicles = (await dbConnection.QueryAsync<Vehicle>(this.getAllVehiclesCrime, new { crimeID = crimeID })).ToList();

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
