using CrimeSystem.Services.Interfaces;

namespace CrimeSystem.DTOs.Responses;

public class CrimesWithVehicleReportResponse : BaseAPIResponse {
    public List<string> occurrences { get; set; } = new List<string>();

    public CrimesWithVehicleReportResponse(List<CrimesWithVehiclesReport> occurrences) {
        occurrences.ForEach(x => this.occurrences.Add($"year: {x.year} | CrimesOccurrences: {x.quant}"));
    }
}
