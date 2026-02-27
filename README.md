# 📝 ToDoList API

Uma API RESTful em ASP.NET Core para gerenciamento de tarefas.

## 📌 Funcionalidades

- CRUD completo de tarefas.
- Alteração de status com regras de negócio.
- Enum `EStatus` (`Pendente`, `EmProgresso`, `Concluido`, `Cancelado`).
- Camadas separadas por responsabilidade (API, Application, Domain, Database, IoC).
- Swagger habilitado para documentação e testes de endpoint.

## 🛠️ Tecnologias

- ASP.NET Core 8
- Entity Framework Core
- SQL Server
- C# 12

## 📁 Estrutura do projeto

```text
ToDoList/
├── ToDoList.API.Internal/
├── ToDoList.Application/
├── ToDoList.Domain/
├── ToDoList.Database/
├── ToDoList.Ioc/
└── ToDoList.Shared/
```

## 🔗 Endpoints principais (v1)

### Alteração de status

- `PATCH /api/v1/Tarefa/{id}/status`

### CRUD de tarefas

- `GET /api/v1/TarefaCrud`
- `GET /api/v1/TarefaCrud/{id}`
- `POST /api/v1/TarefaCrud`
- `PUT /api/v1/TarefaCrud/{id}`
- `DELETE /api/v1/TarefaCrud/{id}`

## ▶️ Como executar

1. Configure o `DbConfig:ConnectionString` nos `appsettings`.
2. (Opcional) aplique as migrations.
3. Execute a API:

```bash
dotnet run --project ToDoList.API.Internal
```

## 👨‍💻 Autor

Desenvolvido com 💙 por **Namanosbad**.
