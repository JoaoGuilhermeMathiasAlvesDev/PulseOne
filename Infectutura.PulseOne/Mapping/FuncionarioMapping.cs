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
    public class FuncionarioMapping : IEntityTypeConfiguration<Funcionario>
    {
        public void Configure(EntityTypeBuilder<Funcionario> builder)
        {

            builder.ToTable("Funiconarios");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome).HasMaxLength(250).IsRequired();

            builder.HasOne(x => x.Usuario)
             .WithMany()
             .HasForeignKey(x => x.UsuarioId)
             .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Estabelecimento)
                .WithMany(e=> e.Funcionarios)
                .HasForeignKey(x => x.EstabelecimentoId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
