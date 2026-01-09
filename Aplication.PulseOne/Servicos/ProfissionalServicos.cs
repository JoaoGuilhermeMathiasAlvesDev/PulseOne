using Aplication.PulseOne.IServicos;
using Aplication.PulseOne.Logic;
using Aplication.PulseOne.Models.Profissional;
using Dominio.PulseOne.Entiteis;
using Infectutura.PulseOne.IRepository;
using Infectutura.PulseOne.IRepository.IUnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.PulseOne.Servicos
{
    public class ProfissionalServicos : IProfissionalServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProfissionalServicos(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ProfissionalModel> ObterPorId(Guid FuncionarioId)
        {
            if (FuncionarioId == Guid.Empty)
                throw new ArgumentNullException(nameof(FuncionarioId),"Id não existe na nossa base de Dados.");

            var dados = await _unitOfWork.Profissionais.ObterPorId(FuncionarioId);
            return ProfissionalLogic.MapearParaModel(dados);
        }

        public async Task<List<ProfissionalModel>> ObterPorList(int pagina = 0, int tamanhoPagina = 0)
        {
            var dados = await _unitOfWork.Profissionais.ObterTodos<Profissional>(pagina, tamanhoPagina);

            return dados.Select(ProfissionalLogic.MapearParaModel).ToList();
        }

        public async Task registrar(Guid FuncionarioId)
        {
            var dados = ProfissionalLogic.AdicionarDados(FuncionarioId);

            await _unitOfWork.Profissionais.Adicionar(dados);
        }

        public async Task Remover(Guid FuncionarioId)
        {
            var dados = await _unitOfWork.Profissionais.ObterPorId(FuncionarioId);

            if (dados is null)
                throw new Exception("Funcionario não encontrado. Por esse motivo não foi realizado a remoçao.");


            await _unitOfWork.Profissionais.Remover(dados);

        }
    }
}
