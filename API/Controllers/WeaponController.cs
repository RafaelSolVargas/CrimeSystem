using Microsoft.AspNetCore.Mvc;
using CrimeSystem.Services.Interfaces;
using CrimeSystem.DTOs;
using CrimeSystem.Models;

namespace CrimeSystem.Controllers;

[ApiController]
[Route("")]
public class WeaponController : ControllerBase {
    private IWeaponService _service;

    public WeaponController(IWeaponService WeaponService) {
        this._service = WeaponService;
    }

    [HttpPost("/Weapons")]
    public async Task<ActionResult<Weapon>> CreateWeapon([FromBody] WeaponToCreate WeaponToCreate) {
        var Weapon = await this._service.CreateWeapon(WeaponToCreate);
        return StatusCode(StatusCodes.Status201Created, Weapon);
    }

    [HttpGet("/Weapons")]
    public async Task<ActionResult<Weapon>> GetAll() {
        var Weapons = await this._service.GetAll();

        return StatusCode(StatusCodes.Status200OK, Weapons);
    }

    [HttpGet("/Weapon/{WeaponID}")]
    public async Task<ActionResult<Weapon>> GetWeapon([FromRoute] int WeaponID) {
        var Weapon = await this._service.GetWeapon(WeaponID);

        return StatusCode(StatusCodes.Status200OK, Weapon);
    }

    [HttpDelete("/Weapon/{resourceID}")]
    public async Task<ActionResult<Characteristic>> Delete([FromRoute] int resourceID) {
        var deleted = await this._service.Delete(resourceID);

        if (deleted)
            return StatusCode(StatusCodes.Status204NoContent);
        return StatusCode(StatusCodes.Status404NotFound);
    }
}
