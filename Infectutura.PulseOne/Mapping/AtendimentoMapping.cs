using Dominio.PulseOne.Entiteis;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infectutura.PulseOne.Mapping
{
    public class AtendimentoMapping : IEntityTypeConfiguration<Atendimento>
    {
        public void Configure(EntityTypeBuilder<Atendimento> builder)
        {
            builder.ToTable("Atendimentos");

            builder.HasKey(a => a.Id);

            // relacionamento com cliente
            builder.HasOne(a => a.Cliente)
                .WithMany()
                .HasForeignKey(a => a.ClienteId)
                .OnDelete(DeleteBehavior.Cascade);

            // relacionamento com Agendamento
            builder.HasOne(a => a.agendamento)
                .WithMany()
                .HasForeignKey(a => a.AgendametnoId)
                .OnDelete(DeleteBehavior.Cascade);

            // relacionamento com serviços 
            builder.HasMany(a => a.Servicos)
                .WithMany();
   

            // relacionamento com Produtos
            builder.HasMany(a => a.Produtos)
                .WithMany();

        }
    }
}
