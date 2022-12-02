using Microsoft.AspNetCore.Mvc;
using CrimeSystem.Services.Interfaces;
using CrimeSystem.DTOs;
using CrimeSystem.Models;

namespace CrimeSystem.Controllers;

[ApiController]
[Route("")]
public class CrimePhotoController : ControllerBase {
    private ICrimePhotoService _service;

    public CrimePhotoController(ICrimePhotoService CrimePhotoService) {
        this._service = CrimePhotoService;
    }

    [HttpPost("/CrimePhotos")]
    public async Task<ActionResult<CrimePhoto>> CreateCrimePhoto([FromBody] CrimePhotoToCreate CrimePhotoToCreate) {
        var CrimePhoto = await this._service.CreateCrimePhoto(CrimePhotoToCreate);
        return StatusCode(StatusCodes.Status201Created, CrimePhoto);
    }

    [HttpGet("/CrimePhotos")]
    public async Task<ActionResult<CrimePhoto>> GetAll() {
        var CrimePhotos = await this._service.GetAll();

        return StatusCode(StatusCodes.Status200OK, CrimePhotos);
    }

    [HttpGet("/CrimePhoto/{CrimePhotoID}")]
    public async Task<ActionResult<CrimePhoto>> GetCrimePhoto([FromRoute] int CrimePhotoID) {
        var CrimePhoto = await this._service.GetCrimePhoto(CrimePhotoID);

        return StatusCode(StatusCodes.Status200OK, CrimePhoto);
    }

    [HttpDelete("/crimephoto/{resourceID}")]
    public async Task<ActionResult<Characteristic>> Delete([FromRoute] int resourceID) {
        var deleted = await this._service.Delete(resourceID);

        if (deleted)
            return StatusCode(StatusCodes.Status204NoContent);
        return StatusCode(StatusCodes.Status404NotFound);
    }
}
