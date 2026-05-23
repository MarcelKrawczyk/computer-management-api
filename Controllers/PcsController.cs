using ComputerManagementApi.DTOs;
using ComputerManagementApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace ComputerManagementApi.Controllers;

[ApiController]
[Route("api/pcs")]
public class PcsController : ControllerBase
{
    private readonly IPcService _pcService;

    public PcsController(IPcService pcService)
    {
        _pcService = pcService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _pcService.GetAllAsync();
        return Ok(result);
    }

    [HttpGet("{id}/components")]
    public async Task<IActionResult> GetByIdWithComponents(int id)
    {
        if (id <= 0)
            return BadRequest("Id must be greater than 0.");

        var result = await _pcService.GetByIdWithComponentsAsync(id);

        if (result is null)
            return NotFound($"PC with id {id} was not found.");

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] PcCreateDto dto)
    {
        var created = await _pcService.CreateAsync(dto);
        return CreatedAtAction(nameof(GetByIdWithComponents), new { id = created.Id }, created);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] PcUpdateDto dto)
    {
        if (id <= 0)
            return BadRequest("Id must be greater than 0.");

        var updated = await _pcService.UpdateAsync(id, dto);

        if (!updated)
            return NotFound($"PC with id {id} was not found.");

        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        if (id <= 0)
            return BadRequest("Id must be greater than 0.");

        var deleted = await _pcService.DeleteAsync(id);

        if (!deleted)
            return NotFound($"PC with id {id} was not found.");

        return NoContent();
    }
}
