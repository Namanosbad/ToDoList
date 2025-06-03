using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDoList.Database.Migrations
{
    /// <inheritdoc />
    public partial class AtualizarTarefas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Data",
                table: "Tarefas",
                newName: "DataConclusao");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataCriacao",
                table: "Tarefas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataCriacao",
                table: "Tarefas");

            migrationBuilder.RenameColumn(
                name: "DataConclusao",
                table: "Tarefas",
                newName: "Data");
        }
    }
}
