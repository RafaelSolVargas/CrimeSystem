using CrimeSystem.DTOs;
using CrimeSystem.Models;

namespace CrimeSystem.Services.Interfaces {
    public interface ICharacteristicService {
        Task<Characteristic> CreateCharacteristic(CharacteristicToCreate characteristicToCreate);
        Task<Characteristic> GetCharacteristic(int characteristicID);
        Task<List<Characteristic>> GetAll();
        Task<bool> Delete(int id);
    }
}
