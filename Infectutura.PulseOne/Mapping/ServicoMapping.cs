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
    public class servicoMapping : IEntityTypeConfiguration<Servico>
    {
        public void Configure(EntityTypeBuilder<Servico> builder)
        {
            builder.ToTable("Servicos");

            builder.HasKey(s => s.Id);

            builder.Property(s => s.Nome).HasMaxLength(150).IsRequired();

            builder.Property(s => s.Preco).HasColumnType("decimal(18,2)").IsRequired();

            builder.Property(s => s.Duracao).HasColumnType("decimal(18,2)");


        }
    }
}
