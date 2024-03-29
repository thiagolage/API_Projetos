﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjetosAPI.Database;

#nullable disable

namespace ProjetosAPI.Migrations
{
    [DbContext(typeof(ProjetosAPIContext))]
    [Migration("20240310145139_Coluna_DataConclusao_Nulo")]
    partial class Coluna_DataConclusao_Nulo
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ProjetosAPI.Models.Comentario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTimeOffset>("DataCriacao")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("IdTarefa")
                        .HasColumnType("int");

                    b.Property<int>("IdUsuario")
                        .HasColumnType("int");

                    b.Property<string>("Texto")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Comentarios");
                });

            modelBuilder.Entity("ProjetosAPI.Models.Funcao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Funcoes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Nome = "Gerente"
                        },
                        new
                        {
                            Id = 2,
                            Nome = "Desenvolvedor"
                        });
                });

            modelBuilder.Entity("ProjetosAPI.Models.LogComentario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTimeOffset>("DataAlteracao")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("IdComentario")
                        .HasColumnType("int");

                    b.Property<int>("IdUsuario")
                        .HasColumnType("int");

                    b.Property<string>("NovoValor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ValorAnterior")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("LogComentarios");
                });

            modelBuilder.Entity("ProjetosAPI.Models.LogTarefa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CampoModificado")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("DataAlteracao")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("IdTarefa")
                        .HasColumnType("int");

                    b.Property<int>("IdUsuario")
                        .HasColumnType("int");

                    b.Property<string>("NovoValor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ValorAnterior")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("LogTarefas");
                });

            modelBuilder.Entity("ProjetosAPI.Models.PrioridadeTarefa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PrioridadeTarefa");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Descricao = "Baixa"
                        },
                        new
                        {
                            Id = 2,
                            Descricao = "Média"
                        },
                        new
                        {
                            Id = 3,
                            Descricao = "Alta"
                        });
                });

            modelBuilder.Entity("ProjetosAPI.Models.Projeto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTimeOffset>("DataCriacao")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdUsuarioAssignee")
                        .HasColumnType("int");

                    b.Property<int>("IdUsuarioCriador")
                        .HasColumnType("int");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Projetos");
                });

            modelBuilder.Entity("ProjetosAPI.Models.StatusTarefa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("StatusTarefa");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Descricao = "Pendente"
                        },
                        new
                        {
                            Id = 2,
                            Descricao = "Em Andamento"
                        },
                        new
                        {
                            Id = 3,
                            Descricao = "Concluída"
                        });
                });

            modelBuilder.Entity("ProjetosAPI.Models.Tarefa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTimeOffset?>("DataConclusao")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset>("DataCriacao")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset>("DataVencimento")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdProjeto")
                        .HasColumnType("int");

                    b.Property<int>("IdUsuarioAssignee")
                        .HasColumnType("int");

                    b.Property<int>("Prioridade")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Titulo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Tarefas");
                });

            modelBuilder.Entity("ProjetosAPI.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<int>("Funcao")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Ativo = true,
                            Funcao = 1,
                            Nome = "Usuario Gerente"
                        },
                        new
                        {
                            Id = 2,
                            Ativo = true,
                            Funcao = 2,
                            Nome = "Usuario Desenvolvedor"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
