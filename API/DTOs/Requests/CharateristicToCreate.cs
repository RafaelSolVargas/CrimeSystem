namespace CrimeSystem.DTOs;

public class CharacteristicToCreate {
    public string description { get; set; }
    public CharacteristicToCreate(string description) {
        this.description = description;
    }
}
