using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Application.Interfaces;
using ToDoList.Application.Requests;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ToDoList.API.Internal.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [Produces("application/json")]
    public class TarefaController : ControllerBase
    {
        private readonly ITarefaService _tarefaService;

        public TarefaController(ITarefaService tarefaService) => _tarefaService = tarefaService;

        /// <summary>
        /// Altera o status de uma tarefa (ex: Em Progresso, Concluído).
        /// </summary>
        /// <param name="id">ID da tarefa a ser atualizada.</param>
        /// <param name="request">Dados da nova alteração de status.</param>
        /// <returns>Status 200 com o resultado da alteração ou erro 400 se o ID não coincidir.</returns>
        [HttpPatch("{id}/status")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> AlterarStatus(Guid id, [FromBody] AlterarStatusRequest request)
        {
            if (id != request.Id)
                return BadRequest("O ID da URL e do corpo não coincidem.");

            var resultado = await _tarefaService.AlterarStatusAsync(request);
            return Ok(resultado);
        }
    }
}
