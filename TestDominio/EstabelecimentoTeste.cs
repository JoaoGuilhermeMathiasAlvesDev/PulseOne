using Dominio.PulseOne.Entiteis;
using Dominio.PulseOne.Entiteis.ObjectValue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDominio
{
    public class EstabelecimentoTeste
    {

        private const string NomeValido = "Matriz Teste";
        private const string RuaValida = "Rua das Flores";
        private const string NumeroValido = "100A";
        private const string CidadeValida = "São Paulo";
        private const string EstadoValido = "SP";
        private const string CepValido = "01000-000";

        [Fact]
        public void CriandoEstabelecimentoValido()
        {
            var enderecoValido = new Endereco(RuaValida,NumeroValido,CidadeValida,EstadoValido,CepValido);
            var estabelecimento = new Estabelecimento(NomeValido , enderecoValido);
           
            Assert.Equal(NomeValido, estabelecimento.Nome);
            Assert.Equal(enderecoValido , estabelecimento.Endereco);
        }

        [Theory]
        [InlineData(null, "Nome do estabelecimento não pode ser vazio.")]
        [InlineData("", "Nome do estabelecimento não pode ser vazio.")]
        [InlineData(" ", "Nome do estabelecimento não pode ser vazio.")]
        public void CriandoEstabelecimentoComNomeInvalido(string nome, string mensagemExececao)
        {

            var enderecoValido = new Endereco(RuaValida, NumeroValido, CidadeValida, EstadoValido, CepValido);
            Action act = () => new Estabelecimento(nome, enderecoValido);

            var ex = Assert.Throws<ArgumentException>(act);

            Assert.Contains(mensagemExececao, ex.Message);
        }

        [Fact]
        public void CriandoEstabelecimentoSemEndereco()
        {
            var enderecoValido = new Endereco(RuaValida, NumeroValido, CidadeValida, EstadoValido, CepValido);
            var estabelecimento = new Estabelecimento(NomeValido, enderecoValido);

            Action act = () => estabelecimento.DefinirDados(NomeValido, null);

            var ex = Assert.Throws<ArgumentNullException>(act);

            Assert.Contains("Endereço é obrigatório.", ex.Message);
        }
    }
}
