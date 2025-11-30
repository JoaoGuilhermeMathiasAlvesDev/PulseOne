using Dominio.PulseOne.Entiteis.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.PulseOne.Entiteis
{
    public class Categoria : EntityBase
    {
        public string Nome { get; private set; }
        public bool Ativo { get;private set; }
        public int Codigo { get;private set; }
        public ICollection<Produto> Produtos { get; set; }

        public Categoria(string Nome)
        {
            DefinirCategoria(Nome);

        }

        public void DefinirCategoria(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("Categoria Precisa ter uma nome.");

            Nome  = nome;
            Codigo = 0;
            Ativo = true;

            Produtos = new List<Produto>();
        }

        public void AdicionarProdutos(List<Produto> produtos)
        {
            if (produtos == null)
                throw new ArgumentNullException("A lista de produtos não pode ser nula.");

            foreach (var produto in produtos)
            {
                Produtos.Add(produto);
            }
        }

        public bool Desativar() => Ativo = false;   

        public bool Ativar() => Ativo = true;

    }
}
