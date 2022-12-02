using Microsoft.AspNetCore.Mvc;
using CrimeSystem.Services.Interfaces;
using CrimeSystem.DTOs;
using CrimeSystem.Models;

namespace CrimeSystem.Controllers;

[ApiController]
[Route("")]
public class VehicleController : ControllerBase {
    private IVehicleService _service;

    public VehicleController(IVehicleService VehicleService) {
        this._service = VehicleService;
    }

    [HttpPost("/Vehicles")]
    public async Task<ActionResult<Vehicle>> CreateVehicle([FromBody] VehicleToCreate VehicleToCreate) {
        var Vehicle = await this._service.CreateVehicle(VehicleToCreate);
        return StatusCode(StatusCodes.Status201Created, Vehicle);
    }

    [HttpGet("/Vehicles")]
    public async Task<ActionResult<Vehicle>> GetAll() {
        var Vehicles = await this._service.GetAll();

        return StatusCode(StatusCodes.Status200OK, Vehicles);
    }

    [HttpGet("/Vehicle/{VehicleID}")]
    public async Task<ActionResult<Vehicle>> GetVehicle([FromRoute] int VehicleID) {
        var Vehicle = await this._service.GetVehicle(VehicleID);

        return StatusCode(StatusCodes.Status200OK, Vehicle);
    }

    [HttpDelete("/Vehicle/{resourceID}")]
    public async Task<ActionResult<Characteristic>> Delete([FromRoute] int resourceID) {
        var deleted = await this._service.Delete(resourceID);

        if (deleted)
            return StatusCode(StatusCodes.Status204NoContent);
        return StatusCode(StatusCodes.Status404NotFound);
    }
}
