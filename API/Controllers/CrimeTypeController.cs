using Microsoft.AspNetCore.Mvc;
using CrimeSystem.Services.Interfaces;
using CrimeSystem.DTOs;
using CrimeSystem.Models;

namespace CrimeSystem.Controllers;

[ApiController]
[Route("")]
public class CrimeTypeController : ControllerBase {
    private ICrimeTypeService _service;

    public CrimeTypeController(ICrimeTypeService CrimeTypeService) {
        this._service = CrimeTypeService;
    }

    [HttpPost("/CrimeTypes")]
    public async Task<ActionResult<CrimeType>> CreateCrimeType([FromBody] CrimeTypeToCreate CrimeTypeToCreate) {
        var CrimeType = await this._service.CreateCrimeType(CrimeTypeToCreate);
        return StatusCode(StatusCodes.Status201Created, CrimeType);
    }

    [HttpGet("/CrimeTypes")]
    public async Task<ActionResult<CrimeType>> GetAll() {
        var CrimeTypes = await this._service.GetAll();

        return StatusCode(StatusCodes.Status200OK, CrimeTypes);
    }

    [HttpGet("/CrimeType/{CrimeTypeID}")]
    public async Task<ActionResult<CrimeType>> GetCrimeType([FromRoute] int CrimeTypeID) {
        var CrimeType = await this._service.GetCrimeType(CrimeTypeID);

        return StatusCode(StatusCodes.Status200OK, CrimeType);
    }

    [HttpDelete("/CrimeType/{resourceID}")]
    public async Task<ActionResult<Characteristic>> Delete([FromRoute] int resourceID) {
        var deleted = await this._service.Delete(resourceID);

        if (deleted)
            return StatusCode(StatusCodes.Status204NoContent);
        return StatusCode(StatusCodes.Status404NotFound);
    }
}
