using Microsoft.EntityFrameworkCore;
using ToDoList.Database.EntitiesConfiguration;
using ToDoList.Domain.Entities;

namespace ToDoList.Database
{
    public class ToDoListDbContext : DbContext
    {
        public DbSet<Tarefa> Tarefas { get; set; }

        public ToDoListDbContext(DbContextOptions<ToDoListDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TarefaEntityConfiguration());
        }
    }
}
