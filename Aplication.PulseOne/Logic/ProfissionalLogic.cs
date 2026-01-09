using Aplication.PulseOne.Models.Estabelecimento;
using Aplication.PulseOne.Models.Funcionario;
using Aplication.PulseOne.Models.Profissional;
using Aplication.PulseOne.Models.Usuario;
using Dominio.PulseOne.Entiteis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.PulseOne.Logic
{
    public static class ProfissionalLogic
    {
        public static Profissional AdicionarDados(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentNullException(nameof(id), "ID do funcionário inválido.");

            var dados = new Profissional(id);

            return dados;
        }

        public static ProfissionalModel MapearParaModel(Profissional p)
        {
            if (p is null) return null;

            return new ProfissionalModel
            {
                Id = p.Id,
                Funcionario = p.Funcionario == null ? null : new FuncionarioModel
                {
                    Id = p.Id,
                    Nome = p.Funcionario.Nome,

                    Usuario = p.Funcionario?.Usuario == null ? null : new UsuarioModel
                    {
                        Id = p.Funcionario.Usuario.Id,
                        Email = p.Funcionario.Usuario.Email,
                        Perfil = p.Funcionario.Usuario.Perfil,

                    },

                    Estabelecimento = p.Funcionario?.Estabelecimento == null ? null : new EstabelecimentoModel
                    {
                        id = p.Funcionario.Estabelecimento.Id,
                        Nome = p.Funcionario.Estabelecimento.Nome,
                    }
                }

            };
        }
    }
}
