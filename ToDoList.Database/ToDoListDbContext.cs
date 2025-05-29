using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDoList.Domain.Entities;
using ToDoList.Database.EntitiesConfiguration;

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
