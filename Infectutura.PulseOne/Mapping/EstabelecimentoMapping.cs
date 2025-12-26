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
    public class EstabelecimentoMapping : IEntityTypeConfiguration<Estabelecimento>
    {
        public void Configure(EntityTypeBuilder<Estabelecimento> builder)
        {
            builder.ToTable("Estabelecimentos");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Nome);

            // Relacionamento 1:1 com Endereco
            builder.OwnsOne(e => e.Endereco, endereco =>
            {
                endereco.Property(p => p.Logradouro).HasMaxLength(200).IsRequired();
                endereco.Property(p => p.Numero).HasMaxLength(20);
                endereco.Property(p => p.Cidade).HasMaxLength(100).IsRequired();
                endereco.Property(p => p.Estado).HasMaxLength(50).IsRequired();
                endereco.Property(p => p.CEP).HasMaxLength(10).IsRequired();
            });

            // Relacionamento 1:N com Funcionarios
            builder.HasMany(e => e.Funcionarios)
                   .WithOne(f => f.Estabelecimento) 
                   .HasForeignKey(f => f.EstabelecimentoId);

        }
    }
}
