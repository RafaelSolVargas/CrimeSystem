namespace CrimeSystem.DTOs;

public class VehicleToCreate {
    public string model { get; set; }
    public string type { get; set; }
    public string plateNumber { get; set; }
    public VehicleToCreate(string model, string placa, string type) {
        this.model = model;
        this.plateNumber = placa;
        this.type = type;
    }
}
