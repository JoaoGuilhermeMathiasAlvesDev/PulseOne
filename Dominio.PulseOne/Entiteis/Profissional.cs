using Dominio.PulseOne.Entiteis.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.PulseOne.Entiteis
{
    public class Profissional : EntityBase
    {
        public Funcionario Funcionario { get; set; }
        public Guid FuncionarioId { get; set; }

        public Profissional(Guid funcionarioId)
        {
            DefinirProfissional(funcionarioId);
        }

        public void DefinirProfissional(Guid funcionarioId)
        {
            if (funcionarioId == Guid.Empty)
                throw new ArgumentNullException("O funcionario tem que te um Identificaçao para ser colocado com profissional.");

            FuncionarioId = funcionarioId;
        }
    }
}
