using ToDoList.Application.Requests;
using ToDoList.Application.Responses;
using ToDoList.Domain.Entities;
using ToDoList.Domain.Interfaces;

namespace ToDoList.Application.Interfaces;

public interface ITarefaService
{
    Task<AlterarStatusResponse> AlterarStatusAsync(AlterarStatusRequest request);
}
