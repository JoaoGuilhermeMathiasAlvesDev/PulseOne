using Aplication.PulseOne.IServicos;
using Aplication.PulseOne.Logic;
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
                throw new ArgumentNullException("Objeto não pode ser vazio.");
            
            var adicionarNovoUsuario = UsuarioLogic.PrepararNovoUsuario(model);

            await _uofw.Usuarios.Adicionar(adicionarNovoUsuario);
            await _uofw.CommitTransactionAsync();
        }

        public async Task Atualizar(AtualizarUsuarioModel model)
        {
          
            var usuarioExistente = await _uofw.Usuarios.ObterPorId(model.Id);
            
            if (usuarioExistente is null)
                throw new Exception("Usuário não encontrado.");

            UsuarioLogic.AtualizarEntidade(usuarioExistente, model);

            await _uofw.Usuarios.Atualizar(usuarioExistente);
            await _uofw.CommitTransactionAsync();
        }

        public async Task<UsuarioModel> ObterUsuario(Guid id)
        {
            if (id == Guid.Empty) throw new ArgumentNullException("id");

            var usuario = await _uofw.Usuarios.ObterPorId(id);

            return UsuarioLogic.MapearParaModel(usuario);
        }

        public async Task<List<UsuarioModel>> ObterUsuarios(int pagina = 0, int tamanhoPagina = 0)
        {
            var usuarios = await _uofw.Usuarios.ObterTodos<Usuario>(pagina, tamanhoPagina);

            return usuarios.Select(UsuarioLogic.MapearParaModel).ToList();
        }

        public async Task Remover(Guid id)
        {
            var usuario = await _uofw.Usuarios.ObterPorId(id);

            if (usuario == null)
                throw new ArgumentNullException("id não encontrado. por favor digiti um Id existente.");

            await _uofw.Usuarios.Remover(usuario);
            await _uofw.CommitTransactionAsync();
        }
    }
}
