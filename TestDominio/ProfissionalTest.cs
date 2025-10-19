using Dominio.PulseOne.Entiteis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDominio
{
    public class ProfissionalTest
    {
        private readonly Guid _FuncionarioId = Guid.NewGuid();

        [Fact]        
        public void Conctrutor_DadosValidos_DeveCriarFuncionarioCorretor()
        {
            var novoProfissional = new Profissional(_FuncionarioId);

            Assert.NotNull(novoProfissional);
            Assert.Equal(_FuncionarioId,novoProfissional.FuncionarioId);
        }

        [Theory]
        [InlineData("00000000-0000-0000-0000-000000000000", "O funcionario tem que te um Identificaçao para ser colocado com profissional.")]
        [Trait("Funcionario", "Exececao")]
        public void Conctrutor_DadosInvalido_DeveCriarUmaExecao(Guid fucinonarioId, string mensagemExecao)
        {
            Action act = () => new Profissional(fucinonarioId);
            var ex = Assert.Throws<ArgumentNullException>(act);

            Assert.Contains(mensagemExecao ,ex.Message);
        }
    }
}
