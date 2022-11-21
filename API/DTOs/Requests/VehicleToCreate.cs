namespace CrimeSystem.DTOs;

public class VehicleToCreate {
    public string model { get; set; }
    public string type { get; set; }
    public string placa { get; set; }
    public VehicleToCreate(string model, string placa, string type) {
        this.model = model;
        this.placa = placa;
        this.type = type;
    }
}