using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PhrasalVerbs.API.Mapping;
using PhrasalVerbs.Application.Services;
using PhrasalVerbs.Contracts.Requests;
using PhrasalVerbs.API.Auth;
using Asp.Versioning;

namespace PhrasalVerbs.API.Controllers;

[ApiController]
[ApiVersion("1.0")]
public class PhrasalVerbsController : ControllerBase
{
    private readonly IPhrasalVerbsService _service;

    public PhrasalVerbsController(IPhrasalVerbsService service)
    { 
        _service = service;
    }

    [Authorize(AuthConstants.AdminUserPolicyName)]
    [HttpPost(Endpoints.PhrasalVerbs.Create)]
    public async Task<IActionResult> Create([FromBody] CreatePhrasalVerbRequest request, CancellationToken token)
    {
        var requestVerb = request.MapToPhrasalVerb();
        var newVerb = await _service.CreateAsync(requestVerb, token);

        if (newVerb is null)
            return Ok();

        return CreatedAtAction(nameof(Get), new { idOrSlug = newVerb.Id }, newVerb.MapToPhrasalVerbResponse());
    }

    [Authorize]
    [HttpGet(Endpoints.PhrasalVerbs.Get)]
    public async Task<IActionResult> Get([FromRoute] string idOrSlug, CancellationToken token)
    {
        var verb = Guid.TryParse(idOrSlug, out var id) 
            ? await _service.GetByIdAsync(id, token) 
            : await _service.GetBySlugAsync(idOrSlug, token);

        return verb is not null ? Ok(verb.MapToPhrasalVerbResponse()) : NotFound();
    }

    [Authorize]
    [HttpGet(Endpoints.PhrasalVerbs.GetAll)]
    public async Task<IActionResult> GetAll([FromQuery] GetAllPhrasalVerbsRequest request, CancellationToken token)
    {
        var options = request.MapToOptions();

        var verbs = await _service.GetAllAsync(options, token);
        var verbsCount = await _service.GetCountAsync(options.Verb, options.Particle, token);

        return Ok(verbs.MapToPhrasalVerbsResponse(options.Page, options.PageSize, verbsCount));
    }

    [Authorize(AuthConstants.AdminUserPolicyName)]
    [HttpPut(Endpoints.PhrasalVerbs.Update)]
    public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdatePhrasalVerbRequest request, CancellationToken token)
    {
        var verb = request.MapToPhrasalVerb(id);

        var updated = await _service.UpdateAsync(verb, token);
        return updated is not null ? Ok(verb.MapToPhrasalVerbResponse()) : NotFound();
    }

    [Authorize(AuthConstants.AdminUserPolicyName)]
    [HttpDelete(Endpoints.PhrasalVerbs.Delete)]
    public async Task<IActionResult> Delete([FromRoute] Guid id, CancellationToken token)
    {
        var deleted = await _service.DeleteByIdAsync(id, token);
        return deleted ? Ok() : NotFound();
    }
}
