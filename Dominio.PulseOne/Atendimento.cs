using Dominio.PulseOne.Entiteis;
using Dominio.PulseOne.Entiteis.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.PulseOne
{
    public class Atendimento : EntityBase
    {
        public Guid ClienteId { get;private set; }
        public Cliente Cliente { get;private set; }
        public Guid AgendametnoId { get;private set; }
        public Agendamento agendamento { get;private set; }
        public ICollection<Servicos> Servicos { get;private set; }
        public ICollection<Produto> Produtos { get; private set; }

        public bool Finalizado { get; set; }

        public Atendimento()
        {
            
        }


    }
}