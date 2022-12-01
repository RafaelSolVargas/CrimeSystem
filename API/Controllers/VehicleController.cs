using Microsoft.AspNetCore.Mvc;
using CrimeSystem.Services.Interfaces;
using CrimeSystem.DTOs;
using CrimeSystem.Models;

namespace CrimeSystem.Controllers;

[ApiController]
[Route("")]
public class VehicleController : ControllerBase {
    private IVehicleService _VehicleService;

    public VehicleController(IVehicleService VehicleService) {
        this._VehicleService = VehicleService;
    }

    [HttpPost("/Vehicles")]
    public async Task<ActionResult<Vehicle>> CreateVehicle([FromBody] VehicleToCreate VehicleToCreate) {
        var Vehicle = await this._VehicleService.CreateVehicle(VehicleToCreate);
        return StatusCode(StatusCodes.Status201Created, Vehicle);
    }

    [HttpGet("/Vehicles")]
    public async Task<ActionResult<Vehicle>> GetAll() {
        var Vehicles = await this._VehicleService.GetAll();

        return StatusCode(StatusCodes.Status200OK, Vehicles);
    }

    [HttpGet("/Vehicle/{VehicleID}")]
    public async Task<ActionResult<Vehicle>> GetVehicle([FromRoute] int VehicleID) {
        var Vehicle = await this._VehicleService.GetVehicle(VehicleID);

        return StatusCode(StatusCodes.Status200OK, Vehicle);
    }
}
