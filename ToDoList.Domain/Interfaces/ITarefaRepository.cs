using System.Security.Principal;
using ToDoList.Domain.Entities;

namespace ToDoList.Domain.Interfaces
{
    public interface ITarefaRepository
    {
        Task<IEnumerable<Tarefa>> ListarAsync();
        Task AddAsync(Tarefa tarefa);

    }
}
