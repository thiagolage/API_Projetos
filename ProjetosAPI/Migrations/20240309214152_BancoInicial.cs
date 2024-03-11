using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProjetosAPI.Migrations
{
    /// <inheritdoc />
    public partial class BancoInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Funcoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcoes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LogComentarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdComentario = table.Column<int>(type: "int", nullable: false),
                    DataAlteracao = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ValorAnterior = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NovoValor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdUsuario = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogComentarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LogTarefas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdTarefa = table.Column<int>(type: "int", nullable: false),
                    DataAlteracao = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CampoModificado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ValorAnterior = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NovoValor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdUsuario = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogTarefas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PrioridadeTarefa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrioridadeTarefa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Projetos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataCriacao = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    IdUsuarioCriador = table.Column<int>(type: "int", nullable: false),
                    IdUsuarioAssignee = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projetos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StatusTarefa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusTarefa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Funcao = table.Column<int>(type: "int", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tarefas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataVencimento = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Prioridade = table.Column<int>(type: "int", nullable: false),
                    IdUsuarioAssignee = table.Column<int>(type: "int", nullable: false),
                    IdProjeto = table.Column<int>(type: "int", nullable: false),
                    ProjetoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tarefas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tarefas_Projetos_ProjetoId",
                        column: x => x.ProjetoId,
                        principalTable: "Projetos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Comentarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdTarefa = table.Column<int>(type: "int", nullable: false),
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    DataCriacao = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    Texto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TarefaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comentarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comentarios_Tarefas_TarefaId",
                        column: x => x.TarefaId,
                        principalTable: "Tarefas",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Funcoes",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { 1, "Gerente" },
                    { 2, "Desenvolvedor" }
                });

            migrationBuilder.InsertData(
                table: "PrioridadeTarefa",
                columns: new[] { "Id", "Descricao" },
                values: new object[,]
                {
                    { 1, "Baixa" },
                    { 2, "Média" },
                    { 3, "Alta" }
                });

            migrationBuilder.InsertData(
                table: "StatusTarefa",
                columns: new[] { "Id", "Descricao" },
                values: new object[,]
                {
                    { 1, "Pendente" },
                    { 2, "Em Andamento" },
                    { 3, "Concluída" }
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Ativo", "Funcao", "Nome" },
                values: new object[,]
                {
                    { 1, true, 1, "Usuario Gerente" },
                    { 2, true, 2, "Usuario Desenvolvedor" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comentarios_TarefaId",
                table: "Comentarios",
                column: "TarefaId");

            migrationBuilder.CreateIndex(
                name: "IX_Tarefas_ProjetoId",
                table: "Tarefas",
                column: "ProjetoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comentarios");

            migrationBuilder.DropTable(
                name: "Funcoes");

            migrationBuilder.DropTable(
                name: "LogComentarios");

            migrationBuilder.DropTable(
                name: "LogTarefas");

            migrationBuilder.DropTable(
                name: "PrioridadeTarefa");

            migrationBuilder.DropTable(
                name: "StatusTarefa");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Tarefas");

            migrationBuilder.DropTable(
                name: "Projetos");
        }
    }
}
