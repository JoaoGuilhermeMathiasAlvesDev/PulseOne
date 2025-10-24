using Dominio.PulseOne.Entiteis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDominio
{
    public class AgendamentoTest
    {
        private readonly Guid _idClient = Guid.NewGuid();
        private readonly Guid _idServico = Guid.NewGuid();
        private readonly Guid _idProfissional = Guid.NewGuid();
        private readonly DateTime _dataHora = DateTime.Now;
        private int status = 1;

        [Fact]
        public void Conctrutor_DadosValidos_DeveCriarAgendamentoCorretor()
        {
            var novoAgendamento = new Agendamento(_idClient,_idProfissional,_idServico,_dataHora,status);

            Assert.NotNull(novoAgendamento);
            Assert.Equal(_idClient, novoAgendamento.ClienteId);
            Assert.Equal(_idServico,novoAgendamento.ServicoId);
            Assert.Equal(_idProfissional,novoAgendamento.ProfissionalId);
            Assert.Equal(status,(int)novoAgendamento.Status);
        }

        [Theory]
        [InlineData("00000000-0000-0000-0000-000000000000", "Cada agendamento precisar ter um cliente.")]
        [Trait("Agendamento", "Exececao")]
        public void Conctrutor_DadosInvalido_DeveRetornaUmaExercecaoCliente(Guid idClinte,string mensagemExececao)
        {
            Action act = () => new Agendamento(idClinte, _idProfissional, _idServico, _dataHora, status);
            var ex = Assert.Throws<ArgumentException>(act);

            Assert.Contains(mensagemExececao, ex.Message);
        }

        [Theory]
        [InlineData("00000000-0000-0000-0000-000000000000", "Precisar ter um profissional.")]
        [Trait("Agendamento", "Exececao")]
        public void Conctrutor_DadosInvalido_DeveRetornaUmaExercecaoProfissional(Guid idProfissional, string mensagemExececao)
        {
            Action act = () => new Agendamento(_idClient, idProfissional, _idServico, _dataHora, status);
            var ex = Assert.Throws<ArgumentException>(act);

            Assert.Contains(mensagemExececao, ex.Message);
        }

        [Theory]
        [InlineData("00000000-0000-0000-0000-000000000000", "Precisar ter um serviço.")]
        [Trait("Agendamento", "Exececao")]
        public void Conctrutor_DadosInvalido_DeveRetornaUmaExercecaoServico(Guid idServico, string mensagemExececao)
        {
            Action act = () => new Agendamento(_idClient, _idProfissional, idServico, _dataHora, status);
            var ex = Assert.Throws<ArgumentException>(act);

            Assert.Contains(mensagemExececao, ex.Message);
        }

        [Theory]
        [InlineData(99, "Esse status não existe!")]
        [Trait("Agendamento", "Exececao")]
        public void ValidarStatus_StatusNaoDefinidoNoEnum_DeveLancarArgumentExceptionComMensagemCorreta(int enumInvalido, string mensagemExercecao)
        {

            Action act = () => new Agendamento(_idClient, _idProfissional,_idServico, _dataHora, enumInvalido);
            var ex = Assert.Throws<ArgumentException>(act);

            Assert.Contains(mensagemExercecao, ex.Message);

        }
    }
}
