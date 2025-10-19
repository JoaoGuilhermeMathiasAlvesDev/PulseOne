using Dominio.PulseOne.Entiteis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDominio
{
    public class FuncionarioTest
    {
        private readonly string _nomeFuncionario = "Joao Guilherme";
        private readonly Guid _idUsuario = Guid.NewGuid();
        private readonly Guid _idEstabelecimento = Guid.NewGuid();

        [Fact]
        [Trait("Funcionario","Construtor")]
        public void Construtor_ComParametrosValidos_DeveCriarUmFuncionarioCorretamente()
        {
            var novoFuncionario = new Funcionario(_nomeFuncionario, _idUsuario,_idEstabelecimento);

            Assert.NotNull(novoFuncionario);
            Assert.Equal(_nomeFuncionario,novoFuncionario.Nome);
            Assert.Equal(_idUsuario,novoFuncionario.UsuarioId);
            Assert.Equal(_idEstabelecimento, novoFuncionario.EstabelecimentoId);
        }

        [Theory]
        [InlineData("", "Funcionario precisar ter um nome. Por gentileza! Pode digitar um Nome")]
        [InlineData(" ", "Funcionario precisar ter um nome. Por gentileza! Pode digitar um Nome")]
        [Trait("Funcionario", "Excecao")]
        public void ConstrutorComParamentoNomeInvalidoDeveDarUmaExecao(string nomeInvalido, string mensagemEsperada)
        {
             Action act = () => new Funcionario(nomeInvalido,_idUsuario, _idEstabelecimento);

            var ex = Assert.Throws<ArgumentException>(act);

            Assert.Contains(mensagemEsperada, ex.Message);
        }

        [Theory]
        [InlineData("", "Funcionario precisar ter um nome. Por gentileza! Pode digitar um Nome")]
        [InlineData(" ", "Funcionario precisar ter um nome. Por gentileza! Pode digitar um Nome")]
        [Trait("Funcionario", "Excecao")]
        public void Construtor_ComParamentoNomeInvalido_DeveDarUmaExecao(string nomeInvalido, string mensagemEsperada)
        {
            Action act = () => new Funcionario(nomeInvalido, _idUsuario, _idEstabelecimento);

            var ex = Assert.Throws<ArgumentException>(act);

            Assert.Contains(mensagemEsperada, ex.Message);
        }

        [Theory]
        [InlineData("00000000-0000-0000-0000-000000000000", "Funcionario precisa te um Identificação de Usuario!")]
        [Trait("Funcionario","Exececao")]
        public void Construtor_ComParametroUsuarioIdInvalido_DeveDarExecao(Guid usuarioId,string mensagemEsperada)
        {
            Action act = () =>  new Funcionario( _nomeFuncionario,usuarioId, _idEstabelecimento);
            var ex = Assert.Throws<ArgumentException>(act);

            Assert.Contains(mensagemEsperada, ex.Message);
        }

        [Theory]
        [InlineData("00000000-0000-0000-0000-000000000000", "Funcinonario Precisa esta vinculado a um estabelecimento.")]
        [Trait("Funcionario", "Exececao")]
        public void Construtor_ComParametroEstabelecimentoIdInvalido_DeveDarExecao(Guid estabelecimentoId,string mensagemEsperada)
        {
            Action act = ()=> new Funcionario(_nomeFuncionario,_idUsuario,estabelecimentoId);
            var ex = Assert.Throws<ArgumentException>(act);

            Assert.Contains(mensagemEsperada,ex.Message);
        }

    }
}
