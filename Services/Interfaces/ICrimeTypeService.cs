using CrimeSystem.DTOs;
using CrimeSystem.Models;

namespace CrimeSystem.Services.Interfaces {
    public interface ICrimeTypeService {
        Task<CrimeType> CreateCrimeType(CrimeTypeToCreate crimeTypeToCreate);
        Task<CrimeType> GetCrimeType(int crimeTypeID);
        Task<List<CrimeType>> GetAll();
        Task<bool> Delete(int id);
    }
}
