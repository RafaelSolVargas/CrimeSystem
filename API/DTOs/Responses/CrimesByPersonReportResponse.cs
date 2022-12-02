using CrimeSystem.Services.Interfaces;

namespace CrimeSystem.DTOs.Responses;

public class CrimesByPersonReport : BaseAPIResponse {
    public List<string> occurrences { get; set; } = new List<string>();

    public CrimesByPersonReport(List<CrimeByPersonReport> occurrences) {
        occurrences.ForEach(x => this.occurrences.Add($"PersonID: {x.personID} | Name: {x.name} | CrimesOccurrences: {x.quant}"));
    }
}
