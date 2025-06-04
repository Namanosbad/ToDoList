using Microsoft.AspNetCore.Mvc;
using ToDoList.Application.Interfaces;
using ToDoList.Application.Requests;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ToDoList.API.Internal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefaController : ControllerBase
    {
        private readonly ITarefaService _tarefaService;

        public TarefaController(ITarefaService tarefaService)
        {
            _tarefaService = tarefaService;
        }

        [HttpPatch("{id}/status")]
        public async Task<IActionResult> AlterarStatus(Guid id, [FromBody] AlterarStatusRequest request)
        {
            if (id != request.Id)
                return BadRequest("O ID da URL e do corpo não coincidem.");

            var resultado = await _tarefaService.AlterarStatusAsync(request);
            return Ok(resultado);
        }

    }
}
