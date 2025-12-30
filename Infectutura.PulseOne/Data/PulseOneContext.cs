using Dominio.PulseOne.Entiteis;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infectutura.PulseOne.Data
{
    public class PulseOneContext : DbContext
    {
        public PulseOneContext(DbContextOptions<PulseOneContext>options) :base(options) { }

        public DbSet<Agendamento> Agendamentos { get; set; }
        public DbSet<Atendimento> Atendimentos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Estabelecimento> Estabelecimentos { get; set; }
        public DbSet<Financerio> Financeiros { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Profissional> Profissionais { get; set; }
        public DbSet<Recepcao> Recepcoes { get; set; }
        public DbSet<Servico> Servicos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PulseOneContext).Assembly);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;
            }

            base.OnModelCreating(modelBuilder);
        }

    }
}
