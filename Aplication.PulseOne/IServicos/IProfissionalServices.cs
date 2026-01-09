using Aplication.PulseOne.Models.Profissional;
using Dominio.PulseOne.Entiteis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.PulseOne.IServicos
{
    public interface IProfissionalServices
    {
        Task registrar(Guid FuncionarioId);
        Task Remover(Guid FuncionarioId);
        Task<ProfissionalModel> ObterPorId(Guid FuncionarioId);
        Task<List<ProfissionalModel>> ObterPorList(int pagina = 0, int tamanhoPagina = 0);
    }
}
