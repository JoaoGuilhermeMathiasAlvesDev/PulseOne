using Dominio.PulseOne.Entiteis;
using FluentAssertions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TestDominio
{
    public class AtendimentoTest
    {
        private readonly Guid _clienteId;
        private readonly Guid _agendamentoId;
        private readonly Guid _categoria;

        public AtendimentoTest()
        {
            // Define IDs válidos que serão usados para cada teste
            _clienteId = Guid.NewGuid();
            _agendamentoId = Guid.NewGuid();
        }

        [Fact]
        public void ConstrutorDeveCriarAtendimentosValidos()
        {
            var atendimento = new Atendimento(_clienteId, _agendamentoId);

            atendimento.Should().NotBeNull();
            atendimento.ClienteId.Should().Be(_clienteId);
            atendimento.AgendametnoId.Should().Be(_agendamentoId);
            atendimento.Finalizado.Should().BeFalse();

        }

        [Fact]
        public void ConstrutorDeveGerarUmaExcptionPorCausaDoIdVazioCliente()
        {
            Assert.Throws<ArgumentNullException>(() => new Atendimento(Guid.Empty, _agendamentoId));
        }

        [Fact]
        public void Construtor_DeveLancarArgumentNullException_QuandoAgendamentoIdForVazio()
        {
            Assert.Throws<ArgumentNullException>(()=> new Atendimento(_clienteId, Guid.Empty));
        }

        [Fact]
        public void AdcionarServico_DeveAdicionarServicoALista()
        {
            var atendimento = new Atendimento(_clienteId, _agendamentoId);
            var servicos = new Servico("Serviço Mecanico", 500);

            atendimento.AdcionarServico(servicos);

            atendimento.Servicos.Should().Contain(servicos).And.HaveCount(1);
        }

        [Fact]
        public void AdcionarServico_DeveAdicionarProdutoLista()
        {
            var atendimento = new Atendimento(_clienteId, _agendamentoId);
            var produtos = new Produto("Oleo de motor ", 32.50,20,_categoria);

            atendimento.AdicionarProduto(produtos);

            atendimento.Produtos.Should().Contain(produtos).And.HaveCount(1);
        }

        [Fact]
        public void AdcionarServico_DeveLancarArgumentNullException_QuandoServicoForNulo()
        {
            var atendimento = new Atendimento(_clienteId, _agendamentoId);

            Assert.Throws<ArgumentNullException>(() => atendimento.AdcionarServico(null));
        }
    }
}
