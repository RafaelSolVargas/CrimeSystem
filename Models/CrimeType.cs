namespace CrimeSystem.Models;
public class CrimeType {
    public string? name { get; set; }
    public int id { get; set; }

    public CrimeType() { }

    public CrimeType(int id, string name) {
        this.name = name;
        this.id = id;
    }
}
