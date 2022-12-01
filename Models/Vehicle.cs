namespace CrimeSystem.Models;
public class Vehicle {
    public int id { get; set; }
    public string? model { get; set; }
    public string? type { get; set; }
    public string? plateNumber { get; set; }

    public Vehicle() { }

    public Vehicle(string model, string type, string plateNumber) {
        this.model = model;
        this.type = type;
        this.plateNumber = plateNumber;
    }
}
