using Microsoft.AspNetCore.Mvc;
using CrimeSystem.Services.Interfaces;
using CrimeSystem.DTOs;
using CrimeSystem.Models;

namespace CrimeSystem.Controllers;

[ApiController]
[Route("")]
public class CrimePhotoController : ControllerBase {
    private ICrimePhotoService _CrimePhotoService;

    public CrimePhotoController(ICrimePhotoService CrimePhotoService) {
        this._CrimePhotoService = CrimePhotoService;
    }

    [HttpPost("/CrimePhotos")]
    public async Task<ActionResult<CrimePhoto>> CreateCrimePhoto([FromBody] CrimePhotoToCreate CrimePhotoToCreate) {
        var CrimePhoto = await this._CrimePhotoService.CreateCrimePhoto(CrimePhotoToCreate);
        return StatusCode(StatusCodes.Status201Created, CrimePhoto);
    }

    [HttpGet("/CrimePhotos")]
    public async Task<ActionResult<CrimePhoto>> GetAll() {
        var CrimePhotos = await this._CrimePhotoService.GetAll();

        return StatusCode(StatusCodes.Status200OK, CrimePhotos);
    }

    [HttpGet("/CrimePhoto/{CrimePhotoID}")]
    public async Task<ActionResult<CrimePhoto>> GetCrimePhoto([FromRoute] int CrimePhotoID) {
        var CrimePhoto = await this._CrimePhotoService.GetCrimePhoto(CrimePhotoID);

        return StatusCode(StatusCodes.Status200OK, CrimePhoto);
    }
}
