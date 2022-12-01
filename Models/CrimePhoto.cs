namespace CrimeSystem.Models;
public class CrimePhoto {
    public int id { get; set; }
    public string? description { get; set; }
    public byte[]? photo { get; set; }

    public CrimePhoto() { }

    public CrimePhoto(int id, string description, byte[] photo) {
        this.id = id;
        this.description = description;
        this.photo = photo;
    }
}
