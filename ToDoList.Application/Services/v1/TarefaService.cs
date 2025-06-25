using ToDoList.Application.Interfaces;
using ToDoList.Application.Requests;
using ToDoList.Application.Responses;
using ToDoList.Domain.Enums;
using ToDoList.Domain.Interfaces;

namespace ToDoList.Application.Services.v1
{
    public class TarefaService : ITarefaService
    {

        private readonly ITarefaRepository _tarefaRepository;

        public TarefaService(ITarefaRepository tarefaRepository) => _tarefaRepository = tarefaRepository;

        public async Task<AlterarStatusResponse> AlterarStatusAsync(AlterarStatusRequest request)
        {
            var tarefa = await _tarefaRepository.ObterPorIdAsync(request.Id);

            if (tarefa == null)
                throw new KeyNotFoundException("Tarefa não encontrada");

            var statusAnterior = tarefa.Status;

            switch (request.Status)
            {
                case EStatus.EmProgresso:
                    tarefa.EmProgresso();
                    break;
                case EStatus.Concluido:
                    tarefa.Concluido();
                    break;
                default:
                    throw new InvalidOperationException("Status inválido para alteração");
            }

            await _tarefaRepository.AtualizarAsync(tarefa);

            return new AlterarStatusResponse
            {
                Id = tarefa.Id,
                StatusAtual = tarefa.Status,
                Titulo = tarefa.Titulo,
                DataConclusao = (DateTime)tarefa.DataConclusao
            };
        }
    }
}