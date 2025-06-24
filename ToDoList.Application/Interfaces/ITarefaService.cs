using ToDoList.Application.Requests;
using ToDoList.Application.Responses;

namespace ToDoList.Application.Interfaces;

public interface ITarefaService
{
    Task<AlterarStatusResponse> AlterarStatusAsync(AlterarStatusRequest request);
}