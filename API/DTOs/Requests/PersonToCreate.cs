namespace CrimeSystem.DTOs;

public class PersonToCreate {
    public string? rg { get; set; }
    public string? cpf { get; set; }
    public string? name { get; set; }
    public string? fatherName { get; set; }
    public string? motherName { get; set; }
    public DateTime? birthDate { get; set; }
    public List<int>? characteristicIDs { get; set; }
    public float height { get; set; }
    public byte[]? photo { get; set; }

    public PersonToCreate() { }
    public PersonToCreate(string rg, string cpf, string name, string fatherName, string motherName, DateTime bornDate, float height, List<int> characteristicIDs) {
        this.rg = rg;
        this.cpf = cpf;
        this.name = name;
        this.motherName = motherName;
        this.fatherName = fatherName;
        this.birthDate = bornDate;
        this.height = height;
        this.characteristicIDs = characteristicIDs;
    }
}
