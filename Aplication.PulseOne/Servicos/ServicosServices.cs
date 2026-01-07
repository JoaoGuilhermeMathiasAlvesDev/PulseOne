using Aplication.PulseOne.IServicos;
using Aplication.PulseOne.Models.Servico;
using Aplication.PulseOne.Validation;
using Dominio.PulseOne.Entiteis;
using Infectutura.PulseOne.IRepository.IUnitOfWork;
using Infectutura.PulseOne.Reposotory.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.PulseOne.Servicos
{
    public class ServicosServices : IServicosServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public ServicosServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Adicionar(AdicionarServicoModel model)
        {
            if(model is null)
                throw new ArgumentNullException("Todos os campos tem que ser preenchido.");

            var servicos = ServicoLogic.AdicionarDados(model);

            await _unitOfWork.Servicos.Adicionar(servicos);
            await _unitOfWork.CommitTransactionAsync();
        }

        public async Task Atualizar(AtualizarServicoModel model)
        {
           var  servicoDados =  await _unitOfWork.Servicos.ObterPorId(model.Id);

            if (servicoDados is null)
                throw new ArgumentException("Serviço não encontrado.");
            
            ServicoLogic.AtualizarDados(servicoDados, model);

            await _unitOfWork.Servicos.Atualizar(servicoDados);
            await _unitOfWork.CommitTransactionAsync();
        }

        public async Task<ServicoModel> ObterUsuario(Guid id)
        {
            var servico =  await _unitOfWork.Servicos.ObterPorId(id);
            
            return ServicoLogic.MapearParaModel(servico);
        }

        public async Task<List<ServicoModel>> ObterUsuarios(int pagina = 0, int tamanhoPagina = 0)
        {
            var servicos = await _unitOfWork.Servicos.ObterTodos<Servico>(pagina, tamanhoPagina);

            return servicos.Select(ServicoLogic.MapearParaModel).ToList();
        }

        public async Task Remover(Guid id)
        {
            var servico = await _unitOfWork.Servicos.ObterPorId(id);
            if (servico == null)
                throw new ArgumentNullException("id não encontrado. por favor digiti um Id existente.");

            await _unitOfWork.Servicos.Remover(servico);
            await _unitOfWork.CommitTransactionAsync();
        }
    }
}
