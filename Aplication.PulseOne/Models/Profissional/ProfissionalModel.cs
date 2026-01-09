using Aplication.PulseOne.Models.Funcionario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.PulseOne.Models.Profissional
{
    public class ProfissionalModel
    {
        public Guid Id { get; set; }
        public FuncionarioModel Funcionario { get; set; }
        public Guid FuncionarioId { get; set; }
    }
}
