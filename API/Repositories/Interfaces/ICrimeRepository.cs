using CrimeSystem.DTOs;
using CrimeSystem.Models;

namespace CrimeSystem.Repositories.Interfaces;

public interface ICrimeRepository {
    Task<Crime> CreateCrime(CrimeToCreate crimeToCreate);
    Task<Crime> GetCrime(int crimeID);
    Task<List<Crime>> GetAll();
}
