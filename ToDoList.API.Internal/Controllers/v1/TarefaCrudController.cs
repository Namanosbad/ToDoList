using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Domain.Entities;
using ToDoList.Domain.Interfaces;

namespace ToDoList.API.Internal.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class TarefaCrudController : ControllerBase
    {
        private readonly IRepository<Tarefa> _repo;

        public TarefaCrudController(IRepository<Tarefa> repo) => _repo = repo;

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _repo.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var tarefa = await _repo.GetByIdAsync(id);
            return tarefa is null ? NotFound() : Ok(tarefa);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Tarefa tarefa)
        {
            var result = await _repo.AddAsync(tarefa);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] Tarefa tarefa)
        {
            if (id != tarefa.Id) return BadRequest("Id do corpo não corresponde ao da URL.");
            if (!await _repo.ExistsAsync(id)) return NotFound();

            await _repo.UpdateAsync(tarefa);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (!await _repo.ExistsAsync(id)) return NotFound();

            await _repo.DeleteAsync(id);
            return NoContent();
        }
    }
}
