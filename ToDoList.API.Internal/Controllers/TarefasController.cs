using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Database.Repository;
using ToDoList.Domain.Entities;
using ToDoList.Domain.Interfaces;

namespace ToDoList.API.Internal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefasController : ControllerBase
    {
        private readonly ITarefaRepository _tarefasRepository;

        public TarefasController(ITarefaRepository tarefasRepository)
        {
            _tarefasRepository = tarefasRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Listar()
        {
            var tarefas = await _tarefasRepository.ListarAsync();
            return Ok(tarefas);
        }

        [HttpPost]
        public async Task<IActionResult> Criar([FromBody] Tarefa tarefa)
        {
            await _tarefasRepository.AddAsync(tarefa);
            return CreatedAtAction(nameof(Listar), new { id = tarefa.Id }, tarefa);
        }

    } 
}
