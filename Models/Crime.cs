namespace CrimeSystem.Models;
public class Crime {
    public DateTime data { get; set; }
    public int id { get; set; }

    public Crime(int id, DateTime data) {
        this.data = data;
        this.id = id;
    }
}
