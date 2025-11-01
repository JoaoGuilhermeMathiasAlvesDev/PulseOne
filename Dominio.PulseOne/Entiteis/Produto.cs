using Dominio.PulseOne.Entiteis.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.PulseOne.Entiteis
{
    public class Produto : EntityBase
    {
        public string  Nome { get; private set ; }
        public double Preco { get;private set; }
        public int Estoque { get;private set; }
        public bool Disponivel { get; private set; }

        public Produto(string nome, double preco, int estoque)
        {
            DefinirDados(nome, preco, estoque);
        }

        public void DefinirDados(string nome, double preco, int estoque)
        {
            if (estoque < 0)
                throw new ArgumentException("Estoque tem que ser maior que zero.");

            if (preco <= 0)
                throw new ArgumentException("Produto precisa ter um preço.");

            Nome = nome;
            Estoque = estoque;
            Preco = preco;
            Disponivel = true;
        }

        public void RetiraDoEstoque(int quantidadDePedidos)
        {
            if (quantidadDePedidos <= 0)
                throw new ArgumentException("A quantidade de pedido deve ser maior que zero.");

            if (Estoque < quantidadDePedidos)
                throw new ArgumentException("A quantidade de pedido não pode ser maior que quandidade de produto no estoque.");

            var novaQuantidade = Estoque - quantidadDePedidos;

            Estoque = novaQuantidade;
        }

        public void AdiconarNoEstoque(int quandiadeParaAcrescentar)
        {
            var novaQuantidade = Estoque + quandiadeParaAcrescentar;

            Estoque = novaQuantidade;
        }

        public bool ProdutoDisponivel() => Disponivel = true;
        public bool ProdutoIndisponivel() => Disponivel = false;
    }
}
