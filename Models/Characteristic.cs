namespace CrimeSystem.Models;
public class Characteristic {
    public int id { get; set; }
    public string description { get; set; }

    public Characteristic(int id, string description) {
        this.id = id;
        this.description = description;
    }
}
