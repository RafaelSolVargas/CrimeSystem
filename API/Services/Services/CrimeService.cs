using CrimeSystem.DTOs;
using CrimeSystem.Models;
using CrimeSystem.Repositories.Interfaces;
using CrimeSystem.Services.Interfaces;

namespace CrimeSystem.Services;

public class CrimeService : ICrimeService {
    private ICrimeRepository crimeRepository;

    public CrimeService(ICrimeRepository crimeRepository) {
        this.crimeRepository = crimeRepository;
    }

    public Task<Crime> CreateCrime(CrimeToCreate crimeToCreate) {
        return this.crimeRepository.CreateCrime(crimeToCreate);
    }

    public Task<List<Crime>> GetAll() {
        return this.crimeRepository.GetAll();
    }

    public Task<Crime> GetCrime(int crimeID) {
        return this.crimeRepository.GetCrime(crimeID);
    }
}
