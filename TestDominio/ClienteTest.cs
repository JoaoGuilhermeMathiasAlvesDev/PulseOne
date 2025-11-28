using Dominio.PulseOne.Entiteis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace TestDominio
{
    public class ClienteTest
    {
        private readonly string _nome = "joao guilherme";
        private readonly string _telefone = "21999209408";
        private readonly string _email = "joaoguilhermemalves@gmail.com";

        [Fact]
        public void ConctrutorAdicionar()
        {
            var cliente = new Cliente(_nome, _telefone, _email);

            Assert.NotNull(cliente);
            Assert.Equal(_email, cliente.Email);
            Assert.Equal(_telefone, cliente.NumeroTelefone);
            Assert.Equal(_email, cliente.Email);
        }

        [Theory]
        [InlineData("", "O cliente precisa ter um Nome.")]
        [InlineData(" ", "O cliente precisa ter um Nome.")]
        [InlineData(null, "O cliente precisa ter um Nome.")]
        public void Construtor_DeveLancarArgumentNullException_QuandoNomeInvalido(string nomeInvalido, string mensagemErro)
        {

            var ex = Assert.Throws<ArgumentNullException>(() =>
                new Cliente(nomeInvalido, _telefone, _email)
            );

            Assert.Contains(mensagemErro, ex.Message);
        }

        [Theory]
        [InlineData("", "O cliente precisa de um numero de telefone para contato.")]
        [InlineData(" ", "O cliente precisa de um numero de telefone para contato.")]
        [InlineData(null, "O cliente precisa de um numero de telefone para contato.")]
        public void ConctrutorPassandoCampoNumeroVazio(string numeroInvalidos, string mensagemErro)
        {
            var ex = Assert.Throws<ArgumentNullException>(() =>
                new Cliente(_nome, numeroInvalidos, _email)
            );

            Assert.Contains(mensagemErro, ex.Message);
        }

        [Theory]
        [InlineData("", "O cliente precisa cadastrar o e-mail.")]
        [InlineData(" ", "O cliente precisa cadastrar o e-mail.")]
        [InlineData(null, "O cliente precisa cadastrar o e-mail.")]
        public void ConctrutorPassandoCampoEmailVazio(string emailInvalido, string mensagemErro)
        {
            var ex = Assert.Throws<ArgumentNullException>(() => new Cliente(_nome, _telefone, emailInvalido));

            Assert.Contains(mensagemErro,ex.Message);
        }
    }
}
