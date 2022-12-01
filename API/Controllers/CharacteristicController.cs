using Microsoft.AspNetCore.Mvc;
using CrimeSystem.Services.Interfaces;
using CrimeSystem.DTOs;
using CrimeSystem.Models;

namespace CrimeSystem.Controllers;

[ApiController]
[Route("")]
public class CharacteristicController : ControllerBase {
    private ICharacteristicService _CharacteristicService;

    public CharacteristicController(ICharacteristicService CharacteristicService) {
        this._CharacteristicService = CharacteristicService;
    }

    [HttpPost("/Characteristics")]
    public async Task<ActionResult<Characteristic>> CreateCharacteristic([FromBody] CharacteristicToCreate CharacteristicToCreate) {
        var Characteristic = await this._CharacteristicService.CreateCharacteristic(CharacteristicToCreate);
        return StatusCode(StatusCodes.Status201Created, Characteristic);
    }

    [HttpGet("/Characteristics")]
    public async Task<ActionResult<Characteristic>> GetAll() {
        var Characteristics = await this._CharacteristicService.GetAll();

        return StatusCode(StatusCodes.Status200OK, Characteristics);
    }

    [HttpGet("/Characteristic/{CharacteristicID}")]
    public async Task<ActionResult<Characteristic>> GetCharacteristic([FromRoute] int CharacteristicID) {
        var Characteristic = await this._CharacteristicService.GetCharacteristic(CharacteristicID);

        return StatusCode(StatusCodes.Status200OK, Characteristic);
    }
}
