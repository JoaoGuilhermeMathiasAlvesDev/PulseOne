using Aplication.PulseOne.IServicos;
using Aplication.PulseOne.Models.Usuario;
using Dominio.PulseOne.Entiteis;
using Dominio.PulseOne.Entiteis.Enum;
using Infectutura.PulseOne.IRepository.IUnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.PulseOne.Servicos
{
    public class UsuarioServices : IUsuarioServices
    {
        private readonly IUnitOfWork _uofw;

        public UsuarioServices(IUnitOfWork uofw)
        {
            _uofw = uofw;
        }

        public async Task Adicionar(AdicionarUsuarioModel model)
        {
            if (model is null)
                throw new ArgumentNullException("Objeto não pode ser vazio.", HttpStatusCode.BadRequest.ToString());

            var usuario = new Usuario();

            if (!usuario.ConfirmaSenha(model.Senha, model.ConfirmarSenhar))
                throw new Exception("As senha não e igual do Confirma Senhar! por gentilezar digita Novamente.");

            int perfil = (int)model.Perfil;
            var adicionarNovoUsuario = new Usuario(model.Email, model.Senha, perfil);

            await _uofw.Usuarios.Adiconionar(adicionarNovoUsuario);

        }

        public async Task Atualizar(AtualizarUsuarioModel model)
        {
            if (model is null)
                throw new ArgumentNullException("Objeto não pode ser vazio.", HttpStatusCode.BadRequest.ToString());

            var usuario = new Usuario();

            if (!usuario.ConfirmaSenha(model.NovaSenha, model.ConfirmarSenhar))
                throw new Exception("As senha não e igual do Confirma Senhar! por gentilezar digita Novamente.");

            int perfil = (int)model.Perfil;
            var atualizarUsuario = new Usuario(model.NovaSenha, model.Email, perfil);

            await _uofw.Usuarios.Atualizar(atualizarUsuario);
        }

        public async Task<UsuarioModel> ObterUsuario(Guid id)
        {
            if (id == Guid.Empty) throw new ArgumentNullException("id");

            var usuario = await _uofw.Usuarios.ObterPorId(id);

            var result = new UsuarioModel
            {
                Id = id,
                Email = usuario.Email,
                Perfil = usuario.Perfil,
            };

            return result;
        }

        public Task<List<UsuarioModel>> ObterUsuarios()
        {
            throw new NotImplementedException();
        }

        public Task Remover(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
