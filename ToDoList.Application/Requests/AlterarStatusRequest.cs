using ToDoList.Domain.Enums;

namespace ToDoList.Application.Requests;
public class AlterarStatusRequest
{
    public Guid Id { get; set; }
    public EStatus Status { get; set; }
}
