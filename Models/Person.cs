namespace CrimeSystem.Models;
public class Person {
    public int id { get; set; }
    public string? name { get; set; }
    public string? fatherName { get; set; }
    public string? motherName { get; set; }
    public string? cpf { get; set; }
    public string? rg { get; set; }
    public DateTime? dateBirth { get; set; }
    public float height { get; set; }
    public byte[]? photo { get; set; }

    public Person() { }

    public Person(int id, string name, string fatherName, string motherName, string cpf, string rg, DateTime birthDate, int height, byte[] photo) {
        this.id = id;
        this.name = name;
        this.fatherName = fatherName;
        this.motherName = motherName;
        this.cpf = cpf;
        this.rg = rg;
        this.dateBirth = birthDate;
        this.height = height;
        this.photo = photo;
    }
}
