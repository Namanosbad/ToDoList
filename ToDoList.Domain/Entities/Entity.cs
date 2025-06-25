using ToDoList.Domain.Interfaces;

namespace ToDoList.Domain.Entities;
public class Entity : IEntity
{
    public Guid Id { get; set; }
}
