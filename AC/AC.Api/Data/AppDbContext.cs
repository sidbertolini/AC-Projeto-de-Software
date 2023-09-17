using AC.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace AC.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }

        public DbSet<Aluno> Alunos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Aluno>().HasData(new Aluno
            {
                Id = 1,
                Name = "Joao Silva",
                SchoolYear = 2,
                Address = "Rua Doze, 1",
                Birthdate = new DateTime(DateTime.Now.Year - 23, 01, 01),
                School = "Unidade 1",
                DataPagamento = new DateTime(DateTime.Now.Year, DateTime.Now.Month - 1, DateTime.Now.Day),
                PagamentoValidoAte = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day - 1)
            });
            modelBuilder.Entity<Aluno>().HasData(new Aluno
            {
                Id = 2,
                Name = "Jose Marcio",
                Address = "Rua Onze, 2",
                Birthdate = new DateTime(DateTime.Now.Year - 27, 01, 01),
                School = "Unidade 2",
                SchoolYear = 3,
                DataPagamento = new DateTime(DateTime.Now.Year, DateTime.Now.Month - 1, DateTime.Now.Day),
                PagamentoValidoAte = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day)
            });
        }
    }
}