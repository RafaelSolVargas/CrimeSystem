using CrimeSystem.Services.Interfaces;

namespace CrimeSystem.DTOs.Responses;

public class AverageHeightByCrimeResponse : BaseAPIResponse {
    public List<string> occurrences { get; set; } = new List<string>();

    public AverageHeightByCrimeResponse(List<AverageHeightByCrimeTypeReport> occurrences) {
        occurrences.ForEach(x => this.occurrences.Add($"CrimeType: {x.crimeType} | Average Height: {x.average}"));
    }
}
