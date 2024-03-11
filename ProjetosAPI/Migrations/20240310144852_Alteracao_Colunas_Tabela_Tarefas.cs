using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetosAPI.Migrations
{
    /// <inheritdoc />
    public partial class Alteracao_Colunas_Tabela_Tarefas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comentarios_Tarefas_TarefaId",
                table: "Comentarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Tarefas_Projetos_ProjetoId",
                table: "Tarefas");

            migrationBuilder.DropIndex(
                name: "IX_Tarefas_ProjetoId",
                table: "Tarefas");

            migrationBuilder.DropIndex(
                name: "IX_Comentarios_TarefaId",
                table: "Comentarios");

            migrationBuilder.DropColumn(
                name: "ProjetoId",
                table: "Tarefas");

            migrationBuilder.DropColumn(
                name: "TarefaId",
                table: "Comentarios");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DataConclusao",
                table: "Tarefas",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DataCriacao",
                table: "Tarefas",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataConclusao",
                table: "Tarefas");

            migrationBuilder.DropColumn(
                name: "DataCriacao",
                table: "Tarefas");

            migrationBuilder.AddColumn<int>(
                name: "ProjetoId",
                table: "Tarefas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TarefaId",
                table: "Comentarios",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tarefas_ProjetoId",
                table: "Tarefas",
                column: "ProjetoId");

            migrationBuilder.CreateIndex(
                name: "IX_Comentarios_TarefaId",
                table: "Comentarios",
                column: "TarefaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comentarios_Tarefas_TarefaId",
                table: "Comentarios",
                column: "TarefaId",
                principalTable: "Tarefas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tarefas_Projetos_ProjetoId",
                table: "Tarefas",
                column: "ProjetoId",
                principalTable: "Projetos",
                principalColumn: "Id");
        }
    }
}
