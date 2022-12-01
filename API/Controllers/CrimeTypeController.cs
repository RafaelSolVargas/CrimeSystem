using Microsoft.AspNetCore.Mvc;
using CrimeSystem.Services.Interfaces;
using CrimeSystem.DTOs;
using CrimeSystem.Models;

namespace CrimeSystem.Controllers;

[ApiController]
[Route("")]
public class CrimeTypeController : ControllerBase {
    private ICrimeTypeService _CrimeTypeService;

    public CrimeTypeController(ICrimeTypeService CrimeTypeService) {
        this._CrimeTypeService = CrimeTypeService;
    }

    [HttpPost("/CrimeTypes")]
    public async Task<ActionResult<CrimeType>> CreateCrimeType([FromBody] CrimeTypeToCreate CrimeTypeToCreate) {
        var CrimeType = await this._CrimeTypeService.CreateCrimeType(CrimeTypeToCreate);
        return StatusCode(StatusCodes.Status201Created, CrimeType);
    }

    [HttpGet("/CrimeTypes")]
    public async Task<ActionResult<CrimeType>> GetAll() {
        var CrimeTypes = await this._CrimeTypeService.GetAll();

        return StatusCode(StatusCodes.Status200OK, CrimeTypes);
    }

    [HttpGet("/CrimeType/{CrimeTypeID}")]
    public async Task<ActionResult<CrimeType>> GetCrimeType([FromRoute] int CrimeTypeID) {
        var CrimeType = await this._CrimeTypeService.GetCrimeType(CrimeTypeID);

        return StatusCode(StatusCodes.Status200OK, CrimeType);
    }
}
