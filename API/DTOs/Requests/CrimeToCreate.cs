using CrimeSystem.Models;

namespace CrimeSystem.DTOs;

public class CrimeToCreate {
    public List<PersonToCreate>? persons { get; set; }
    public CrimePhotoToCreate? photo { get; set; }
    public List<WeaponToCreate>? weapons { get; set; }
    public List<VehicleToCreate>? vehicles { get; set; }
    public DateTime date { get; set; }
    public int crimeTypeID { get; set; }
}
