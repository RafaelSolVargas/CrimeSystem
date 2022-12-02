using Microsoft.AspNetCore.Mvc;
using CrimeSystem.Services.Interfaces;
using CrimeSystem.DTOs;
using CrimeSystem.Models;

namespace CrimeSystem.Controllers;

public class PersonController : ControllerBase {
    private IPersonService _service;

    public PersonController(IPersonService PersonService) {
        this._service = PersonService;
    }

    [HttpPost("/Persons")]
    public async Task<ActionResult<Person>> CreatePerson([FromBody] PersonToCreate PersonToCreate) {
        var Person = await this._service.CreatePerson(PersonToCreate);
        return StatusCode(StatusCodes.Status201Created, Person);
    }

    [HttpGet("/Persons")]
    public async Task<ActionResult<Person>> GetAll() {
        var Persons = await this._service.GetAll();

        return StatusCode(StatusCodes.Status200OK, Persons);
    }

    [HttpGet("/Person/{PersonID}")]
    public async Task<ActionResult<Person>> GetPerson([FromRoute] int PersonID) {
        var Person = await this._service.GetPerson(PersonID);

        return StatusCode(StatusCodes.Status200OK, Person);
    }

    [HttpGet("/")]
    public ActionResult Welcome() {
        return StatusCode(StatusCodes.Status200OK, "Welcome");
    }

    [HttpDelete("/Person/{resourceID}")]
    public async Task<ActionResult<Characteristic>> Delete([FromRoute] int resourceID) {
        var deleted = await this._service.Delete(resourceID);

        if (deleted)
            return StatusCode(StatusCodes.Status204NoContent);
        return StatusCode(StatusCodes.Status404NotFound);
    }
}
