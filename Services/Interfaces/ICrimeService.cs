using CrimeSystem.DTOs;
using CrimeSystem.Models;

namespace CrimeSystem.Services.Interfaces {
    public interface ICrimeService {
        Task<Crime> CreateCrime(CrimeToCreate crimeToCreate);
        Task<Crime> GetCrime(int crimeID);
        Task<List<Crime>> GetAll();
        Task<bool> Delete(int id);
        Task<List<CrimeByPersonReport>> GetPersonsCrimesOccurrencesReport();
        Task<List<CrimesWithVehiclesReport>> GetCrimesWithVehicleReports();
        Task<List<AverageHeightByCrimeTypeReport>> GetAverageHeightReport();
    }

    public class CrimeByPersonReport {
        public int personID;
        public string? name;
        public int quant;
    }

    public class CrimesWithVehiclesReport {
        public string? year;
        public int quant;
    }
    public class AverageHeightByCrimeTypeReport {
        public string? crimeType;
        public float average;
    }
}
