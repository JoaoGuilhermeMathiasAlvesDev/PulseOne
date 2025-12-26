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
    public class ProfissionalMapping : IEntityTypeConfiguration<Profissional>
    {
        public void Configure(EntityTypeBuilder<Profissional> builder)
        {
            builder.ToTable("Profissionaal");

            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Funcionario)
                .WithMany()
                .HasForeignKey(x => x.FuncionarioId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
