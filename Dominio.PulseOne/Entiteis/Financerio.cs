using Dominio.PulseOne.Entiteis.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.PulseOne.Entiteis
{
    public class Financerio : EntityBase
    {
        public Guid ProfissionalId { get; private set; }
        public Profissional Profissional { get; private set; }

        public double Lucro { get; private set; }

        public double Comissao { get; private set; }
        public DateTime DataReferente { get; private set; }

        public Financerio(Guid profissionalId, double lucro)
        {
            DefinirFinacerio(profissionalId, lucro);
        }

        public void DefinirFinacerio(Guid profissionalId, double lucro)
        {
            if (profissionalId == Guid.Empty)
                throw new ArgumentNullException("Precisa existir um profissional.");

            ProfissionalId = profissionalId;
            Lucro = lucro;
            DataReferente = DateTime.Now;
        }

    }
}
