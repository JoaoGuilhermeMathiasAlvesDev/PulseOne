using Dominio.PulseOne.Entiteis.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.PulseOne.Entiteis
{
    public class Funcionario : EntityBase
    {
        public string Nome { get; private set; }

        public Guid UsuarioId { get; private set; }
        public Usuario Usuario { get; private set; }

        public Guid EstabelecimentoId { get; private set; }
        public Estabelecimento Estabelecimento { get; private set; }

        public Funcionario(string nome, Guid usuarioId,Guid estabelecimentoId)
        {
            Nome = nome;
            UsuarioId = usuarioId;
            EstabelecimentoId = estabelecimentoId;
        }

    }
}
