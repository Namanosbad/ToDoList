using ToDoList.Domain.Enums;

namespace ToDoList.Domain.Entities
{
    public class Tarefa
    {
        public Guid Id { get; set; }

        public string? Titulo { get; set; }

        public string? Descricao { get; set; }

        public DateTime? Data { get; set; }

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
        }

        public void Cancelar()
        {
            if (Status != EStatus.Concluido)
                Status = EStatus.Cancelado;
        }
    }
}
