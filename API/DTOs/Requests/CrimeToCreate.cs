namespace CrimeSystem.DTOs;

public class CrimeToCreate {
    public List<PersonToCreate>? persons { get; set; }
    public CrimePhotoToCreate? photo { get; set; }
    public WeaponToCreate? weapon { get; set; }
    public VehicleToCreate? vehicle { get; set; }
    public DateTime data { get; set; }
}
