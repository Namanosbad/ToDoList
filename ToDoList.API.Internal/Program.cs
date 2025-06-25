using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text.Json.Serialization;
using ToDoList.API.Internal.Extensions;
using ToDoList.Ioc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "ToDoList",
        Description = "Lista de tarefas",
        TermsOfService = new Uri("https://github.com/Namanosbad"),
        Contact = new OpenApiContact
        {
            Name = "Matheus Lima",
            Email = "matheus.limamst@gmail.com",
            Url = new Uri("https://www.linkedin.com/in/matheuslimamst/"),
        },
    });
    var xmlFileName = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFileName));
});


builder.Services.AddServices(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json",
                                        "ToDoListAPI");
    });
    app.ConfigureExceptionHandler();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
