using Dominio.PulseOne.Entiteis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDominio
{
    public class CategoriaTest
    {
        private const string nome = "Livros";
        private const int codigo = 0;
        private bool ativa = true;

        [Fact]
        public void construtorCategariaPassandoCorretamente()
        {
            var novaCategoria = new Categoria(nome);

            Assert.Equal(nome, novaCategoria.Nome);
            Assert.Equal(codigo, novaCategoria.Codigo);
            Assert.True(ativa);
        }

        [Theory]
        [InlineData("", "Categoria Precisa ter uma nome.")]
        [InlineData(" ", "Categoria Precisa ter uma nome.")]
        public void AdiconarProdutoExeceptionNoPreco(string nomeErrado, string mensagemException)
        {
            Action act = () => new Categoria(nomeErrado);

            var ex = Assert.Throws<ArgumentException>(act);

            Assert.Contains(mensagemException, ex.Message);
        }

        [Fact]
        public void DesativarCategoria()
        {
            var categoria = new Categoria(nome);

            categoria.Desativar();

            Assert.False(categoria.Ativo);
        }

        [Fact]
        public void AtivarCategoria()
        {
            var categoria = new Categoria(nome);

            categoria.Desativar();

            if(categoria.Ativo == false)
                categoria.Ativar();

            Assert.True(categoria.Ativo);
        }
    }
}
