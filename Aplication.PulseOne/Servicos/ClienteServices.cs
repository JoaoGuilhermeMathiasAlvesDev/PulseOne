using Aplication.PulseOne.IServicos;
using Aplication.PulseOne.Logic;
using Aplication.PulseOne.Models.Cliente;
using Dominio.PulseOne.Entiteis;
using Infectutura.PulseOne.IRepository.IUnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.PulseOne.Servicos
{
    public class ClienteServices : IClienteServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public ClienteServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Adiconar(AdicionarCliente model)
        {
            if (model is null)
                throw new ArgumentNullException("Todos os campos tem que ser preenchido.");

            var dados = ClienteLogic.AdicionarDados(model);

            await _unitOfWork.Clientes.Adicionar(dados);

        }

        public async Task Atualizar(AtualizarCliente model)
        {
            var Dados = await _unitOfWork.Clientes.ObterPorId(model.Id);

            if (model is null)
                throw new ArgumentNullException("Esse cliente não existe na base de Dados.");

            ClienteLogic.Atualizar(Dados, model);

            await _unitOfWork.Clientes.Atualizar(Dados);

        }

        public async Task<ClienteModel> ObterPorId(Guid guid)
        {
            var resultado = await _unitOfWork.Clientes.ObterPorId(guid);

            return ClienteLogic.MapearParaModel(resultado);
        }

        public async Task<List<ClienteModel>> ObterTodos(int pagina = 0, int tamanhoPagina = 0)
        {
            var  dados = await _unitOfWork.Clientes.ObterTodos<Cliente>(pagina, tamanhoPagina);

            return dados.Select(ClienteLogic.MapearParaModel).ToList();
        }

        public async Task Remover(Guid id)
        {
            var dados = await _unitOfWork.Clientes.ObterPorId(id);

            if (dados is null)
                throw new ArgumentNullException("Esse cliente não existe na base de Dados.");

            await _unitOfWork.Clientes.Remover(dados);
        }
    }
}
