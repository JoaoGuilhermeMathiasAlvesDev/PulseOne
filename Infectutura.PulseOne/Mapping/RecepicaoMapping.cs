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
    public class RecepicaoMapping : IEntityTypeConfiguration<Recepcao>
    {
        public void Configure(EntityTypeBuilder<Recepcao> builder)
        {
            builder.ToTable("Recepcao");

            builder.HasKey(x => x.Id);

            builder.HasOne(r => r.Atendimento)
                .WithMany()
                .HasForeignKey(r => r.AtendimentoId)
                .OnDelete(DeleteBehavior.Cascade);

            // Enum mapeado como string ou int
            builder.Property(r => r.FormaPagamento)
                   .IsRequired()
                   .HasConversion<int>(); // ou .HasConversion<string>() se preferir armazenar como texto

            // Propriedades numéricas
            builder.Property(r => r.ValorTotal)
                   .IsRequired()
                   .HasColumnType("decimal(18,2)");

            builder.Property(r => r.Troco)
                   .IsRequired()
                   .HasColumnType("decimal(18,2)");

        }
    }
}
