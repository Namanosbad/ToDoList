# Etapa 1: build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copiando arquivos .csproj
COPY ["ToDoList.API.Internal/ToDoList.API.Internal.csproj", "ToDoList.API.Internal/"]
COPY ["ToDoList.Application/ToDoList.Application.csproj", "ToDoList.Application/"]
COPY ["ToDoList.Database/ToDoList.Database.csproj", "ToDoList.Database/"]
COPY ["ToDoList.Domain/ToDoList.Domain.csproj", "ToDoList.Domain/"]
COPY ["ToDoList.Ioc/ToDoList.Ioc.csproj", "ToDoList.Ioc/"]
COPY ["ToDoList.Shared/ToDoList.Shared.csproj", "ToDoList.Shared/"]

# Restaurar dependências
RUN dotnet restore "ToDoList.API.Internal/ToDoList.API.Internal.csproj"

# Copiar tudo agora
COPY . .

# Build
WORKDIR "/src/ToDoList.API.Internal"
RUN dotnet build "ToDoList.API.Internal.csproj" -c Release -o /app/build

# Etapa 2: publish
FROM build AS publish
RUN dotnet publish "ToDoList.API.Internal.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Etapa 3: imagem final
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .

# Expor porta
EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080;https://+:8081
ENTRYPOINT ["dotnet", "ToDoList.API.Internal.dll"]
