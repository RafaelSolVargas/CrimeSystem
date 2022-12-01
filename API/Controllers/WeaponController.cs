using Microsoft.AspNetCore.Mvc;
using CrimeSystem.Services.Interfaces;
using CrimeSystem.DTOs;
using CrimeSystem.Models;

namespace CrimeSystem.Controllers;

[ApiController]
[Route("")]
public class WeaponController : ControllerBase {
    private IWeaponService _WeaponService;

    public WeaponController(IWeaponService WeaponService) {
        this._WeaponService = WeaponService;
    }

    [HttpPost("/Weapons")]
    public async Task<ActionResult<Weapon>> CreateWeapon([FromBody] WeaponToCreate WeaponToCreate) {
        var Weapon = await this._WeaponService.CreateWeapon(WeaponToCreate);
        return StatusCode(StatusCodes.Status201Created, Weapon);
    }

    [HttpGet("/Weapons")]
    public async Task<ActionResult<Weapon>> GetAll() {
        var Weapons = await this._WeaponService.GetAll();

        return StatusCode(StatusCodes.Status200OK, Weapons);
    }

    [HttpGet("/Weapon/{WeaponID}")]
    public async Task<ActionResult<Weapon>> GetWeapon([FromRoute] int WeaponID) {
        var Weapon = await this._WeaponService.GetWeapon(WeaponID);

        return StatusCode(StatusCodes.Status200OK, Weapon);
    }
}
