using CrimeSystem.DTOs;
using CrimeSystem.Models;

namespace CrimeSystem.Services.Interfaces {
    public interface ICrimePhotoService {
        Task<CrimePhoto> CreateCrimePhoto(CrimePhotoToCreate crimePhotoToCreate);
        Task<CrimePhoto> GetCrimePhoto(int crimePhotoID);
        Task<List<CrimePhoto>> GetAll();
    }
}
