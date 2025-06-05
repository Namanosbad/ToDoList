
# ToDoList API

Este é um projeto ASP.NET Core que implementa uma API RESTful para gerenciamento de tarefas (ToDoList), estrutura em camadas e uso de repositórios genéricos e específicos.

## Funcionalidades

- CRUD completo de tarefas
- Alteração de status de tarefas com regras de negócio
- Enum `EStatus` para controle de status (`Pendente`, `EmProgresso`, `Concluido`, `Cancelado`)
- Camada de serviço (`TarefaService`) com lógica específica
- Repository pattern com EF Core
- Estrutura organizada em camadas: `API`, `Application`, `Domain`, `Database`, `Ioc`

## Tecnologias

- ASP.NET Core 8
- Entity Framework Core
- SQL Server
- C# 12

## Estrutura do Projeto

```
ToDoList/
├── API/
│   └── Controllers/
├── Application/
│   ├── Services/
│   ├── Interfaces/
│   ├── Requests/Responses
├── Domain/
│   ├── Entities/
│   ├── Enums/
│   └── Interfaces/
├── Database/
│   ├── Repository/
│   └── Context/
├── Ioc/
│   └── ServiceCollectionExtensions.cs
```

## Endpoints Principais

### Tarefas (TarefaController)

- `PATCH /api/tarefa/alterar-status` — Altera o status de uma tarefa
- `GET /api/tarefa/{id}` — Obtém tarefa por ID
- `POST /api/tarefa` — Cria nova tarefa

### CRUD Genérico (GenericTarefaController)

- `GET /api/tarefas`
- `GET /api/tarefas/{id}`
- `POST /api/tarefas`
- `PUT /api/tarefas/{id}`
- `DELETE /api/tarefas/{id}`

## Como Executar

1. Configure o `appsettings.json` com sua `ConnectionString`.
2. Execute as migrations do EF Core se necessário.
3. Rode o projeto via Visual Studio ou CLI:

```bash
dotnet run --project ToDoList.API
```

---

## Autor

Desenvolvido por [Namanosbad].
