namespace CrimeSystem.Models;
public class Crime {
    public List<Person> persons { get; set; }
    public List<Weapon> weapons { get; set; }
    public List<Vehicle> vehicles { get; set; }
    public CrimePhoto? crimePhoto { get; set; }
    public CrimeType? crimeType { get; set; }
    public DateTime date { get; set; }
    public int id { get; set; }

    public Crime() {
        this.persons = new List<Person>();
        this.weapons = new List<Weapon>();
        this.vehicles = new List<Vehicle>();
    }

    public Crime(List<Person> persons, List<Weapon> weapons, List<Vehicle> vehicles, CrimeType crimeType, DateTime date, int id, CrimePhoto crimePhoto) {
        this.persons = persons;
        this.vehicles = vehicles;
        this.weapons = weapons;
        this.crimeType = crimeType;
        this.date = date;
        this.id = id;
        this.crimePhoto = crimePhoto;
    }
}
