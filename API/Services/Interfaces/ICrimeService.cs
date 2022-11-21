using CrimeSystem.DTOs;
using CrimeSystem.Models;

namespace CrimeSystem.Services.Interfaces {
    public interface ICrimeService {
        Task<Crime> CreateCrime(CrimeToCreate crimeToCreate);
        Task<Crime> GetCrime(int crimeID);
        Task<List<Crime>> GetAll();
    }
}
