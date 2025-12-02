using Dominio.PulseOne.Entiteis.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.PulseOne.Entiteis
{
    public class Atendimento : EntityBase
    {
        public Guid ClienteId { get; private set; }
        public Cliente Cliente { get; private set; }
        public Guid AgendametnoId { get; private set; }
        public Agendamento agendamento { get; private set; }
        public ICollection<Servico> Servicos { get;  set; }
        public ICollection<Produto> Produtos { get; set; }

        public bool Finalizado { get; set; }

        public Atendimento(Guid clienteId, Guid agendamento)
        {
            DefinirAtendimento(clienteId, agendamento);
        }

        public void DefinirAtendimento(Guid cliente, Guid agendamento)
        {
            if (cliente == Guid.Empty) throw new ArgumentNullException("Precisa ter um cliente para te um atendimento.");

            if (agendamento == Guid.Empty) throw new ArgumentNullException("Precisa existir uma Agendamento.");

            ClienteId = cliente;
            AgendametnoId = agendamento;   
            
            Servicos = new List<Servico>();
            Produtos = new List<Produto>();
        }

        public void AdcionarServico(Servico servicos)
        {
            if (servicos == null) throw new ArgumentNullException("Por favor, Precisa escolher um serviço");

            Servicos.Add(servicos);
        }

        public void AdicionarProduto(Produto produto)
        {
            Produtos.Add(produto);
        }

        public bool Finalizar(bool finalizar) => Finalizado = true;

        public double ValorTotal()
        {

            double valorProdutoTotal = this.Produtos?.Sum(p => p.Preco) ?? 0.0;
            double valorServicosTotal = this.Servicos?.Sum(s=> s.Preco) ?? 0.0;
            
            return  valorProdutoTotal + valorServicosTotal;
        }
    }
}