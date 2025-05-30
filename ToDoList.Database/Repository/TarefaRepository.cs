using Microsoft.EntityFrameworkCore;
using ToDoList.Domain.Entities;
using ToDoList.Domain.Interfaces;

namespace ToDoList.Database.Repository
{
    public class TarefaRepository : ITarefaRepository
    {
        private readonly ToDoListDbContext _context;

        public TarefaRepository(ToDoListDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Tarefa>> ListarAsync()
        {
            return await _context.Tarefas.ToListAsync();
        }

        public async Task AddAsync(Tarefa tarefa)
        {
            await _context.Tarefas.AddAsync(tarefa);
            await _context.SaveChangesAsync();
        }
    }
}
