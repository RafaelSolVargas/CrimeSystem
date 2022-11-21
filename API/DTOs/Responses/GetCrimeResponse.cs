using CrimeSystem.Models;

namespace CrimeSystem.DTOs.Responses;

public class GetCrimeResponse : BaseAPIResponse {
    public Crime crime { get; set; }

    public GetCrimeResponse(Crime crime) {
        this.crime = crime;

    }
}
