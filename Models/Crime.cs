namespace CrimeSystem.Models;
public class Crime {
    public List<Person> persons { get; set; }
    public List<Weapon> weapons { get; set; }
    public List<Vehicle> vehicles { get; set; }
    public CrimePhoto crimePhoto { get; set; }
    public CrimeType crimeType { get; set; }
    public DateTime data { get; set; }
    public int id { get; set; }

    public Crime(List<Person> persons, List<Weapon> weapons, List<Vehicle> vehicles, CrimeType crimeType, DateTime data, int id, CrimePhoto crimePhoto) {
        this.persons = persons;
        this.vehicles = vehicles;
        this.weapons = weapons;
        this.crimeType = crimeType;
        this.data = data;
        this.id = id;
        this.crimePhoto = crimePhoto;
    }
}
