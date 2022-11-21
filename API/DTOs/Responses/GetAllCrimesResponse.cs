using CrimeSystem.Models;

namespace CrimeSystem.DTOs.Responses;

public class GetAllCrimesResponse : BaseAPIResponse {
    public List<Crime> crimes { get; set; }

    public GetAllCrimesResponse(List<Crime> crimes) {
        this.crimes = crimes;

    }
}
