using Aplication.PulseOne.Models.Estabelecimento;
using Aplication.PulseOne.Models.Usuario;
using Infectutura.PulseOne.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.PulseOne.Models.Funcionario
{
    public class FuncionarioModel
    {
        public Guid Id { get; set; }
        public string Nome { get;  set; }

        public Guid UsuarioId { get;  set; }
        public UsuarioModel Usuario { get; set; }

        public Guid EstabelecimentoId { get; set; }
        public EstabelecimentoModel Estabelecimento { get;  set; }
    }
}
