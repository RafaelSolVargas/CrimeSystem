using Microsoft.AspNetCore.Mvc;
using CrimeSystem.Services.Interfaces;
using CrimeSystem.DTOs;
using CrimeSystem.Models;
using CrimeSystem.DTOs.Responses;

namespace CrimeSystem.Controllers;

[ApiController]
[Route("")]
public class CrimeController : ControllerBase {
    private ICrimeService _service;

    public CrimeController(ICrimeService crimeService) {
        this._service = crimeService;
    }

    [HttpPost("/crimes")]
    public async Task<ActionResult<Crime>> CreateCrime([FromBody] CrimeToCreate crimeToCreate) {
        var crime = await this._service.CreateCrime(crimeToCreate);
        return StatusCode(StatusCodes.Status201Created, crime);
    }

    [HttpGet("/crimes")]
    public async Task<ActionResult<GetAllCrimesResponse>> GetAll() {
        var crimes = await this._service.GetAll();

        return StatusCode(StatusCodes.Status200OK, crimes);
    }

    [HttpGet("/crime/{crimeID}")]
    public async Task<ActionResult<GetCrimeResponse>> GetCrime([FromRoute] int crimeID) {
        var crime = await this._service.GetCrime(crimeID);

        return StatusCode(StatusCodes.Status200OK, crime);
    }

    [HttpDelete("/crime/{resourceID}")]
    public async Task<ActionResult> Delete([FromRoute] int resourceID) {
        var deleted = await this._service.Delete(resourceID);

        if (deleted)
            return StatusCode(StatusCodes.Status204NoContent);
        return StatusCode(StatusCodes.Status404NotFound);
    }

    [HttpGet("/CrimesByPersonReport")]
    public async Task<ActionResult> GetCrimesOccurrenceReport() {
        var report = await this._service.GetPersonsCrimesOccurrencesReport();

        return StatusCode(StatusCodes.Status200OK, new CrimesByPersonReport(report));
    }

    [HttpGet("/CrimesWithVehiclesReport")]
    public async Task<ActionResult> GetCrimesWithVehiclesReport() {
        var report = await this._service.GetCrimesWithVehicleReports();

        return StatusCode(StatusCodes.Status200OK, new CrimesWithVehicleReportResponse(report));
    }

    [HttpGet("/AverageHeightByCrimeType")]
    public async Task<ActionResult> AverageHeightByCrimeType() {
        var report = await this._service.GetAverageHeightReport();

        return StatusCode(StatusCodes.Status200OK, new AverageHeightByCrimeResponse(report));
    }
}
