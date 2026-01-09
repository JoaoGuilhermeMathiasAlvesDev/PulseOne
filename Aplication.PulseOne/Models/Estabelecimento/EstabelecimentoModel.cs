using Aplication.PulseOne.Models.Funcionario;
using Dominio.PulseOne.Entiteis.ObjectValue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.PulseOne.Models.Estabelecimento
{
    public class EstabelecimentoModel
    {
        public Guid id { get; set; }
        public string Nome { get;  set; }
        public Endereco Endereco { get;  set; }
        public ICollection<FuncionarioModel> Funcionarios { get;  set; }
    }
}
