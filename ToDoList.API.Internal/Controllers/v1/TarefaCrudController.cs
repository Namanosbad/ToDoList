using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Domain.Entities;
using ToDoList.Domain.Interfaces;

namespace ToDoList.API.Internal.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [Produces("application/json")]
    public class TarefaCrudController(IRepository<Tarefa> repo) : ControllerBase
    {
        private readonly IRepository<Tarefa> _repo = repo;

        /// <summary>
        /// Retorna todas as tarefas.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var tarefa = await _repo.GetAllAsync();
            return Ok(tarefa);
        }

        /// <summary>
        /// Retorna uma tarefa pelo ID.
        /// </summary>
        /// <param name="id">ID da tarefa.</param>
        [HttpGet("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> GetById(Guid id)
        {
            var tarefa = await _repo.GetByIdAsync(id);
            if (tarefa == null)
            {
                return NotFound();
            }else { return Ok(tarefa); }
        }

        /// <summary>
        /// Cria uma nova tarefa.
        /// </summary>
        /// <param name="tarefa">Objeto da tarefa a ser criada.</param>
        /// <returns>Tarefa criada com localizador.</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Create([FromBody] Tarefa tarefa)
        {
            var result = await _repo.AddAsync(tarefa);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        /// <summary>
        /// Atualiza uma tarefa.
        /// </summary>
        /// <param name="id">ID da tarefa.</param>
        /// <param name="tarefa">Dados atualizados da tarefa.</param>
        /// <returns>NoContent se atualizado, BadRequest se IDs não coincidem, NotFound se não existir.</returns>
        [HttpPut("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Update(Guid id, [FromBody] Tarefa tarefa)
        {
            if (id != tarefa.Id)
            {
                return BadRequest("Id do corpo não corresponde ao da URL.");
            }

            if (!await _repo.ExistsAsync(id))
            {
                return NotFound();
            }

            await _repo.UpdateAsync(tarefa);
            return NoContent();
        }

        /// <summary>
        /// Exclui uma tarefa pelo ID.
        /// </summary>
        /// <param name="id">ID da tarefa.</param>
        /// <returns>NoContent se excluída, NotFound se não existir.</returns>
        [HttpDelete("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (!await _repo.ExistsAsync(id))
            {
                return NotFound();
            }

            await _repo.DeleteAsync(id);
            return NoContent();
        }
    }
}
