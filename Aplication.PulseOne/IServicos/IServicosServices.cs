using Aplication.PulseOne.Models.Servico;
using Aplication.PulseOne.Models.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.PulseOne.IServicos
{
    public interface IServicosServices
    {
        Task Adicionar(AdicionarServicoModel model);
        Task Atualizar(AtualizarServicoModel model);
        Task<List<ServicoModel>> ObterUsuarios(int pagina = 0, int tamanhoPagina = 0);
        Task<ServicoModel> ObterUsuario(Guid id);
        Task Remover(Guid id);
    }
}
