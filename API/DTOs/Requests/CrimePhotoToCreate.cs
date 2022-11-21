namespace CrimeSystem.DTOs;

public class CrimePhotoToCreate {
    public byte[] photo { get; set; }
    public string? description { get; set; }

    public CrimePhotoToCreate(byte[] photo, string description) {
        this.photo = photo;
        this.description = description;
    }

}
