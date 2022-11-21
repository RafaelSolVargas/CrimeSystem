namespace CrimeSystem.DTOs;

public class PersonToCreate {
    public string rg { get; set; }
    public string cpf { get; set; }
    public string name { get; set; }
    public string fatherName { get; set; }
    public string motherName { get; set; }
    public DateTime bornDate { get; set; }
    public CharacteristicToCreate? characteristic { get; set; }
    public int height { get; set; }
    public byte[]? photo { get; set; }

    public PersonToCreate(string rg, string cpf, string name, string fatherName, string motherName, DateTime bornDate, int height, CharacteristicToCreate? characteristic) {
        this.rg = rg;
        this.cpf = cpf;
        this.name = name;
        this.motherName = motherName;
        this.fatherName = fatherName;
        this.bornDate = bornDate;
        this.height = height;
        this.characteristic = characteristic;
    }
}
