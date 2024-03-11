using Microsoft.EntityFrameworkCore;

namespace ProjetosAPI.Database
{
    public class ProjetosAPIContext : DbContext
    {
        public ProjetosAPIContext(DbContextOptions<ProjetosAPIContext> options) : base(options)
        {
            
        }

        public DbSet<Funcao> Funcoes { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Projeto> Projetos { get; set; }

        public DbSet<Tarefa> Tarefas { get; set; }

        public DbSet<Comentario> Comentarios { get; set; }

        public DbSet<LogComentario> LogComentarios { get; set; }

        public DbSet<LogTarefa> LogTarefas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Funcao>().HasData(
                new Funcao { Id = 1, Nome = "Gerente" },
                new Funcao { Id = 2, Nome = "Desenvolvedor" }
                );

            modelBuilder.Entity<Usuario>().HasData(
                new Usuario { Id = 1, Nome = "Usuario Gerente", Ativo = true, Funcao = 1 },
                new Usuario { Id = 2, Nome = "Usuario Desenvolvedor", Ativo = true, Funcao = 2 }
                );

            modelBuilder.Entity<StatusTarefa>().HasData(
                new StatusTarefa { Id = 1, Descricao = "Pendente" },
                new StatusTarefa { Id = 2, Descricao = "Em Andamento" },
                new StatusTarefa { Id = 3, Descricao = "Concluída" }
                );

            modelBuilder.Entity<PrioridadeTarefa>().HasData(
                new PrioridadeTarefa { Id = 1, Descricao = "Baixa" },
                new PrioridadeTarefa { Id = 2, Descricao = "Média" },
                new PrioridadeTarefa { Id = 3, Descricao = "Alta" }
                );
        }
    }
}
