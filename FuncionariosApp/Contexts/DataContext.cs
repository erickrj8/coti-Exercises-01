using FuncionariosApp.Entities;
using Microsoft.EntityFrameworkCore;

namespace FuncionariosApp.Contexts
{
    public class DataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Adicionando a string de conexão do banco de dados
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BDFuncionarios;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False;Command Timeout=30");
        }

        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Empresa> Empresas { get; set; }
    }
}