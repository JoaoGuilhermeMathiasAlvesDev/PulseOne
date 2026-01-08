using Aplication.PulseOne.Models.Cliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.PulseOne.IServicos
{
    public interface IClienteServices
    {
        Task Adiconar(AdicionarCliente model);
        Task Atualizar(AtualizarCliente model);
        Task<List<ClienteModel>> ObterTodos(int pagina = 0, int tamanhoPagina = 0);
        Task<ClienteModel> ObterPorId(Guid guid);
        Task Remover(Guid id);

    }
}
