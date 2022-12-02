using CrimeSystem.DTOs;
using CrimeSystem.Models;

namespace CrimeSystem.Services.Interfaces {
    public interface IWeaponService {
        Task<Weapon> CreateWeapon(WeaponToCreate WeaponToCreate);
        Task<Weapon> GetWeapon(int WeaponID);
        Task<List<Weapon>> GetAll();
        Task<bool> Delete(int id);
    }
}
