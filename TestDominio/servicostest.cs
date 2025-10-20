using Dominio.PulseOne.Entiteis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDominio
{
    public class servicostest
    {
        private readonly string _nome = "Manuteção preventiva";
        private readonly double _preco = 150.00;
        private readonly int _duracao = 50;

        [Fact]
        public void Construto_PassandoParametrosValido_CadastroComSucesso()
        {
            var novoServico = new Servico(_nome, _preco);
            
            Assert.NotNull(novoServico);
            Assert.Equal(_preco, novoServico.Preco);
            Assert.Equal(_nome, novoServico.Nome);

            novoServico.definirTempo(_duracao);
            Assert.Equal(_duracao, novoServico.Duracao);
        }

        [Theory]
        [InlineData("", "Serviço precisa de um Nome.")]
        [InlineData(" ", "Serviço precisa de um Nome.")]
        [Trait("Servico","Exerçao")]
        public void Construto_PassandoParamentroNomeInvalido_TeraUmaexercao(string nome,string mensagemExercao)
        {
            Action act= () => new Servico(nome, _preco);
            var ex = Assert.Throws<ArgumentNullException>(act);

            Assert.Contains(mensagemExercao, ex.Message);
        }

        [Theory]
        [InlineData(0, "Serviço precisa de um valor para ser tabelado para cliente.")]
        public void Construto_PassadoParametroPrecoInvalido_TeraUmaExercao(double preco,string mensagemExercao)
        {
            Action act = () => new Servico(_nome, preco);
            var ex = Assert.Throws<ArgumentNullException>(act);

            Assert.Contains(mensagemExercao , ex.Message);
        }
    }
}
