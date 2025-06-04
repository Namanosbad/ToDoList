using ToDoList.Domain.Entities;

namespace ToDoList.Domain.Interfaces;

public interface ITarefaRepository
{
    Task<Tarefa?> ObterPorIdAsync(Guid id);
    Task AtualizarAsync(Tarefa tarefa);
}
