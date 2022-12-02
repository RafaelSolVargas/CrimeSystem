using Microsoft.AspNetCore.Mvc;
using CrimeSystem.Services.Interfaces;
using CrimeSystem.DTOs;
using CrimeSystem.Models;

namespace CrimeSystem.Controllers;

[ApiController]
[Route("")]
public class CharacteristicController : ControllerBase {
    private ICharacteristicService _service;

    public CharacteristicController(ICharacteristicService CharacteristicService) {
        this._service = CharacteristicService;
    }

    [HttpPost("/Characteristics")]
    public async Task<ActionResult<Characteristic>> CreateCharacteristic([FromBody] CharacteristicToCreate CharacteristicToCreate) {
        var Characteristic = await this._service.CreateCharacteristic(CharacteristicToCreate);
        return StatusCode(StatusCodes.Status201Created, Characteristic);
    }

    [HttpGet("/Characteristics")]
    public async Task<ActionResult<Characteristic>> GetAll() {
        var Characteristics = await this._service.GetAll();

        return StatusCode(StatusCodes.Status200OK, Characteristics);
    }

    [HttpGet("/Characteristic/{CharacteristicID}")]
    public async Task<ActionResult<Characteristic>> GetCharacteristic([FromRoute] int CharacteristicID) {
        var Characteristic = await this._service.GetCharacteristic(CharacteristicID);

        return StatusCode(StatusCodes.Status200OK, Characteristic);
    }

    [HttpDelete("/Characteristic/{resourceID}")]
    public async Task<ActionResult<Characteristic>> Delete([FromRoute] int resourceID) {
        var deleted = await this._service.Delete(resourceID);

        if (deleted)
            return StatusCode(StatusCodes.Status204NoContent);
        return StatusCode(StatusCodes.Status404NotFound);
    }
}
