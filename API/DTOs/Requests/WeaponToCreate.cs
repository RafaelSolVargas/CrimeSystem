namespace CrimeSystem.DTOs;

public class WeaponToCreate {
    public int id { get; set; }
    public string type { get; set; }
    public string register { get; set; }
    public string description { get; set; }
    public bool alreadyExists { get; set; }

    public WeaponToCreate(string type, string register, string description, bool alreadyExists, int id) {
        this.type = type;
        this.description = description;
        this.register = register;
        this.alreadyExists = alreadyExists;
        this.id = id;
    }
}
