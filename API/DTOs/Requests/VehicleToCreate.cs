namespace CrimeSystem.DTOs;

public class VehicleToCreate {
    public int id { get; set; }
    public string? model { get; set; }
    public string? type { get; set; }
    public string? plateNumber { get; set; }
    public bool alreadyExists { get; set; }
    public VehicleToCreate() { }
    public VehicleToCreate(string model, string placa, string type, bool alreadyExists, int id) {
        this.model = model;
        this.plateNumber = placa;
        this.type = type;
        this.alreadyExists = alreadyExists;
        this.id = id;
    }
}
