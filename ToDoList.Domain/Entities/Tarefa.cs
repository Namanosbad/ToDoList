using System.ComponentModel.DataAnnotations;
using ToDoList.Domain.Enums;
using ToDoList.Domain.Interfaces;

namespace ToDoList.Domain.Entities;
public class Tarefa : IEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required(ErrorMessage ="Titulo é obrigatorio")]
    public string? Titulo { get; set; }

    [Required(ErrorMessage = "Descrição é obrigatoria")]
    public string? Descricao { get; set; }

    public DateTime DataCriacao { get; private set; } = DateTime.UtcNow;
    public DateTime? DataConclusao { get; private set; }

    public EStatus Status { get; set; } = EStatus.Pendente;
    public void EmProgresso()
    {
        if (Status == EStatus.Pendente)
            Status = EStatus.EmProgresso;
    }
    public void Concluido()
    {
        if (Status == EStatus.EmProgresso)
            Status = EStatus.Concluido;
        DataConclusao = DateTime.UtcNow;
    }
    public void Cancelar()
    {
        if (Status != EStatus.Concluido)
            Status = EStatus.Cancelado;
    }
}
