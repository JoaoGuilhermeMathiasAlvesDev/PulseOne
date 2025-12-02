using Dominio.PulseOne.Entiteis;
using Dominio.PulseOne.Entiteis.Enum;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDominio
{
    public class Recepcaoteste
    {
        [Fact]
        public void DefinirAtendimento_DeveLancarExcecao_QuandoGuidVazio()
        {
            var recepcao = new Recepcao(Guid.NewGuid());

            Assert.Throws<ArgumentNullException>(()=> recepcao.DefinirAtendimento(Guid.Empty));
        }

        [Fact]
        public void FormaDePagamento_DeveRetornarEnumCorreto_QuandoValorValido()
        {
            var recepcao = new Recepcao(Guid.NewGuid());

            var forma = recepcao.FormaDePagamento((int)FormaPagamentoEnum.Dinheiro);

            Assert.Equal(FormaPagamentoEnum.Dinheiro, forma);
        }

        [Fact]
        public void FormaDePagamento_DeveLancarExcecao_QuandoValorInvalido()
        {
            var recepcao = new Recepcao(Guid.NewGuid());

            Assert.Throws<ArgumentException>(() => recepcao.FormaDePagamento(999));

        }

    }
}
