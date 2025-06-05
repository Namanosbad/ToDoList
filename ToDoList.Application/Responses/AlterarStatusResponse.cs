using ToDoList.Domain.Enums;

namespace ToDoList.Application.Responses;
public class AlterarStatusResponse
{
    public Guid Id { get; set; }
    public string? Titulo { get; set; }
    public EStatus StatusAtual { get; set; }
    public DateTime? DataConclusao { get; set; }
}
