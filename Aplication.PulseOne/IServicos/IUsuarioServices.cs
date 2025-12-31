using Aplication.PulseOne.Models.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.PulseOne.IServicos
{
    public interface IUsuarioServices
    {
        Task Adicionar(AdicionarUsuarioModel model);
        Task Atualizar(AtualizarUsuarioModel model);
        Task<List<UsuarioModel>> ObterUsuarios(int pagina = 0, int tamanhoPagina = 0);
        Task<UsuarioModel> ObterUsuario(Guid id);
        Task Remover(Guid id);
    }
}
