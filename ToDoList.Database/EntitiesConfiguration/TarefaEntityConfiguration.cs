using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDoList.Domain.Entities;

namespace ToDoList.Database.EntitiesConfiguration;
public class TarefaEntityConfiguration : IEntityTypeConfiguration<Tarefa>
{
    public void Configure(EntityTypeBuilder<Tarefa> builder)
    {
        builder.ToTable("Tarefas");

        builder.HasKey(t => t.Id);

        builder.Property(t => t.Id)
               .IsRequired()
               .ValueGeneratedOnAdd();

        builder.Property(t => t.Titulo)
               .HasMaxLength(200);

        builder.Property(t => t.Descricao)
               .HasMaxLength(1000);

        builder.Property(t => t.DataCriacao)
                .IsRequired();

        builder.Property(t => t.DataConclusao);

        builder.Property(t => t.Status)
               .HasConversion<string>()
               .IsRequired();
    }
}