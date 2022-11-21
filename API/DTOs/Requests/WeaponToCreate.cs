namespace CrimeSystem.DTOs;

public class WeaponToCreate {
    public string type { get; set; }
    public string register { get; set; }
    public string description { get; set; }
    public WeaponToCreate(string type, string register, string description) {
        this.type = type;
        this.description = description;
        this.register = register;
    }
}
