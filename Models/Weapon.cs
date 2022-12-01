namespace CrimeSystem.Models;
public class Weapon {
    public int id { get; set; }
    public string? type { get; set; }
    public string? register { get; set; }
    public string? description { get; set; }

    public Weapon() { }

    public Weapon(int id, string type, string register, string description) {
        this.id = id;
        this.type = type;
        this.register = register;
        this.description = description;
    }
}
