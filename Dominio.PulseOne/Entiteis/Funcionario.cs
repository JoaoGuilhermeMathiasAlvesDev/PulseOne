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
            DefinirFuncionario(nome,usuarioId,estabelecimentoId);
        }

        public void DefinirFuncionario(string nome,Guid usuarioId,Guid estabelecimentoId)
        {
            if (nome == string.Empty)
                throw new ArgumentException("Funcuinario precisar ter um nome. Por gentileza! Pode digitar um Nome");

            if (usuarioId == Guid.Empty)
                throw new ArgumentException("Funcionario precisa te um Identificação de Usuario!");

            if (estabelecimentoId == Guid.Empty)
                throw new ArgumentException("Funcinonario Precisa esta vinculado a um estabelecimento.");

            Nome = nome;
            UsuarioId = usuarioId;
            EstabelecimentoId= estabelecimentoId;
        }

    }
}
