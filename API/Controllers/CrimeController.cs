using Microsoft.AspNetCore.Mvc;
using CrimeSystem.Services.Interfaces;
using CrimeSystem.DTOs;
using CrimeSystem.Models;
using CrimeSystem.DTOs.Responses;

namespace CrimeSystem.Controllers;

[ApiController]
[Route("")]
public class CrimeController : ControllerBase {
    private ICrimeService crimeService;

    public CrimeController(ICrimeService crimeService) {
        this.crimeService = crimeService;
    }

    [HttpPost("/crimes")]
    public async Task<ActionResult<Crime>> CreateCrime([FromBody] CrimeToCreate crimeToCreate) {
        var crime = await this.crimeService.CreateCrime(crimeToCreate);
        return StatusCode(StatusCodes.Status201Created, crime);
    }

    [HttpGet("/crimes")]
    public async Task<ActionResult<GetAllCrimesResponse>> GetAll() {
        var crimes = await this.crimeService.GetAll();

        return StatusCode(StatusCodes.Status200OK, crimes);
    }

    [HttpGet("/crime/{crimeID}")]
    public async Task<ActionResult<GetCrimeResponse>> GetCrime([FromRoute] int crimeID) {
        var crime = await this.crimeService.GetCrime(crimeID);

        return StatusCode(StatusCodes.Status200OK, crime);
    }
}
