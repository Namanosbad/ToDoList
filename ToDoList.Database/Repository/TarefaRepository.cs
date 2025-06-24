using ToDoList.Domain.Entities;
using ToDoList.Domain.Interfaces;

namespace ToDoList.Database.Repository
{
    public class TarefaRepository : EFRepository<Tarefa>, ITarefaRepository
    {
        private readonly ToDoListDbContext _context;

        public TarefaRepository(ToDoListDbContext context) : base(context) => _context = context;

        public async Task<Tarefa?> ObterPorIdAsync(Guid id) => await _context.Tarefas.FindAsync(id);

        public async Task AtualizarAsync(Tarefa tarefa)
        {
            _context.Tarefas.Update(tarefa);
            await _context.SaveChangesAsync();
        }
    }
}
