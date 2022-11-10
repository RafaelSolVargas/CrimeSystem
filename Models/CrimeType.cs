namespace CrimeSystem.Models;
public class CrimeType {
    public DateTime data { get; set; }
    public int id { get; set; }

    public CrimeType(int id, DateTime data) {
        this.data = data;
        this.id = id;
    }
}
