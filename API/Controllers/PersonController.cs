using Microsoft.AspNetCore.Mvc;
using CrimeSystem.Services.Interfaces;
using CrimeSystem.DTOs;
using CrimeSystem.Models;

namespace CrimeSystem.Controllers;

[ApiController]
[Route("")]
public class PersonController : ControllerBase {
    private IPersonService _PersonService;

    public PersonController(IPersonService PersonService) {
        this._PersonService = PersonService;
    }

    [HttpPost("/Persons")]
    public async Task<ActionResult<Person>> CreatePerson([FromBody] PersonToCreate PersonToCreate) {
        var Person = await this._PersonService.CreatePerson(PersonToCreate);
        return StatusCode(StatusCodes.Status201Created, Person);
    }

    [HttpGet("/Persons")]
    public async Task<ActionResult<Person>> GetAll() {
        var Persons = await this._PersonService.GetAll();

        return StatusCode(StatusCodes.Status200OK, Persons);
    }

    [HttpGet("/Person/{PersonID}")]
    public async Task<ActionResult<Person>> GetPerson([FromRoute] int PersonID) {
        var Person = await this._PersonService.GetPerson(PersonID);

        return StatusCode(StatusCodes.Status200OK, Person);
    }
}
