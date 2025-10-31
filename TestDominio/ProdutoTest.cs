using Dominio.PulseOne.Entiteis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDominio
{
    public class ProdutoTest
    {
        private readonly string _nome = "Biblia";
        private readonly int _quantidade = 3;
        private readonly double _preco = 45.50;
        private readonly bool _disponivel = true;

        [Fact]
        public void AdiconarProdutoCorretamente()
        {
            var novoProduto = new Produto(_nome, _preco, _quantidade);

            Assert.NotNull(novoProduto);
            Assert.Equal(_preco, novoProduto.Preco);
            Assert.Equal(_nome, novoProduto.Nome);
            Assert.Equal(_quantidade, novoProduto.Estoque);
        }

        [Fact]
        public void AdiconarProdutoCorretamenteDisponibilizandoSendoFalso()
        {
            var novoProduto = new Produto(_nome, _preco, _quantidade);

            Assert.NotNull(novoProduto);
            Assert.Equal(_preco, novoProduto.Preco);
            Assert.Equal(_nome, novoProduto.Nome);
            Assert.Equal(_quantidade, novoProduto.Estoque);

            novoProduto.ProdutoIndisponivel();

            Assert.False(novoProduto.Disponivel);
        }

        [Fact]
        public void AdiconarProdutoCorretamentesSentandoComTrue()
        {
            var novoProduto = new Produto(_nome, _preco, _quantidade);

            Assert.NotNull(novoProduto);
            Assert.Equal(_preco, novoProduto.Preco);
            Assert.Equal(_nome, novoProduto.Nome);
            Assert.Equal(_quantidade, novoProduto.Estoque);

            novoProduto.ProdutoIndisponivel();
            Assert.False(novoProduto.Disponivel);


            novoProduto.ProdutoDisponivel();
            Assert.True(novoProduto.Disponivel);
        }

        [Theory]
        [InlineData(-1.00, "Produto precisa ter um preço.")]
        [InlineData(0.00, "Produto precisa ter um preço.")]
        public void AdiconarProdutoExeceptionNoPreco(double valor, string mensagemException)
        {
            Action act = () => new Produto(_nome, valor, _quantidade);
            
            var ex = Assert.Throws<ArgumentException>(act);

            Assert.Contains(mensagemException, ex.Message);
        }


        [Theory]
        [InlineData(-1, "Estoque tem que ser maior que zero.")]
        public void AdiconarProdutoExeceptionNoEstoque(int quantidade, string mensagemException)
        {
            Action act = () => new Produto(_nome, _preco, quantidade);

            var ex = Assert.Throws<ArgumentException>(act);

            Assert.Contains(mensagemException, ex.Message);
        }

    }
}
