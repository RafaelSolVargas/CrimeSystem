using CrimeSystem.DTOs;
using CrimeSystem.Models;

namespace CrimeSystem.Services.Interfaces {
    public interface IPersonService {
        Task<Person> CreatePerson(PersonToCreate personToCreate);
        Task<Person> GetPerson(int personID);
        Task<List<Person>> GetAll();
        Task<bool> Delete(int id);

    }
}
