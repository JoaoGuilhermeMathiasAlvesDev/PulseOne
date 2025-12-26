using Dominio.PulseOne.Entiteis;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infectutura.PulseOne.Mapping
{
    public class FinanceiroMapping : IEntityTypeConfiguration<Financerio>
    {
        public void Configure(EntityTypeBuilder<Financerio> builder)
        {
            builder.ToTable("Financeiros");

            builder.HasKey(f => f.Id);

            builder.Property(f => f.Lucro);

            builder.Property(f =>  f.Comissao);

            builder.Property(f => f.DataReferente);

            builder.HasOne(f => f.Profissional)
                .WithMany()
                .HasForeignKey(f => f.ProfissionalId)
                .OnDelete(DeleteBehavior.Cascade);  
        }
    }
}
