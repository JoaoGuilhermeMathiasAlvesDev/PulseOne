using Dominio.PulseOne.Entiteis.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.PulseOne.Entiteis
{
    public class Servicos : EntityBase
    {
        public string Nome { get; private set; }
        public double Preco { get; private set; }
        public int Duracao { get; private set; }

        public Servicos(string nome, double preco)
        {
             DefinirSerivco(nome, preco);
        }

        public void DefinirSerivco(string nome, double preco)
        {
            if (nome == string.Empty)
                throw new ArgumentNullException("Serviço precisa de um Nome.");

            if (preco == 0)
                throw new ArgumentNullException("Serviço precisa de um valor para ser tabelado para cliente.");

            Nome = nome;
            Preco = preco;
        }

        public void definirTempo(int duracao)
        {
            Duracao = duracao;
        }
    }
}
