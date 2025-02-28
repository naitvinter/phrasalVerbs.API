using Microsoft.AspNetCore.Mvc;
using PhrasalVerbs.API.Mapping;
using PhrasalVerbs.Application.Repositories;
using PhrasalVerbs.Contracts.Requests;

namespace PhrasalVerbs.API.Controllers;

[ApiController]
public class PhrasalVerbsController : ControllerBase
{
    private readonly IPhrasalVerbsRepository _repository;

    public PhrasalVerbsController(IPhrasalVerbsRepository repository)
    { 
        _repository = repository;
    }

    [HttpPost(Endpoints.PhrasalVerbs.Create)]
    public async Task<IActionResult> Create([FromBody] CreatePhrasalVerbRequest request)
    {
        var requestVerb = request.MapToPhrasalVerb();
        var newVerb = await _repository.CreateAsync(requestVerb);

        return CreatedAtAction(nameof(Get), new { id = newVerb.Id }, newVerb);
    }

    [HttpGet(Endpoints.PhrasalVerbs.Get)]
    public async Task<IActionResult> Get([FromRoute] Guid id)
    {
        var verb = await _repository.GetByIdAsync(id);
        return verb is not null ? Ok(verb.MapToPhrasalVerbResponse()) : NotFound();
    }

    [HttpGet(Endpoints.PhrasalVerbs.GetAll)]
    public async Task<IActionResult> GetAll()
    {
        var verbs = await _repository.GetAllAsync();
        return Ok(verbs.MapToPhrasalVerbsResponse());
    }

    [HttpPut(Endpoints.PhrasalVerbs.Update)]
    public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdatePhrasalVerbRequest request)
    {
        var verb = request.MapToPhrasalVerb(id);

        var updated = await _repository.UpdateAsync(verb);
        return updated ? Ok(verb.MapToPhrasalVerbResponse()) : NotFound();
    }

    [HttpDelete(Endpoints.PhrasalVerbs.Delete)]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        var deleted = await _repository.DeleteByIdAsync(id);
        return deleted ? Ok() : NotFound();
    }
}
