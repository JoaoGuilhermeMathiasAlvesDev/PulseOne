using Dominio.PulseOne.Entiteis.Base;
using Dominio.PulseOne.Entiteis.Enum;
using System;

namespace Dominio.PulseOne.Entiteis
{
    public class Agendamento : EntityBase
    {
        public Guid ClienteId { get;private set; }
        public Cliente Cliente { get;private set; }

        public Guid ProfissionalId { get;private set; }
        public Profissional Profissional { get;private set; }

        public Guid ServicoId { get;private set; }
        public Servico Servicos { get; set; }

        public DateTime DataHora { get;private set; }
        public StatusCliente Status { get; set; }


        protected Agendamento() { }

        public Agendamento(Guid clienteId, Guid profissionalId,Guid servicoId,DateTime datahora,int status)
        {
            DefinirAgendametno(clienteId, profissionalId, servicoId, datahora, status);
        }

        public void DefinirAgendametno(Guid clienteId, Guid profissionalId, Guid servicoId, DateTime datahora, int status)
        {
            if (clienteId == Guid.Empty)
                throw new ArgumentException("Cada agendamento precisar ter um cliente.");

            if (profissionalId == Guid.Empty) throw new ArgumentException("Precisar ter um profissional.");

            if (servicoId == Guid.Empty) throw new ArgumentException("Precisar ter um serviço.");

            if (!System.Enum.IsDefined(typeof(StatusCliente), status))
                throw new ArgumentException("Esse status não existe!");

            ClienteId = clienteId;
            ProfissionalId = profissionalId;
            ServicoId = servicoId;
            Status = (StatusCliente)status;
            DataHora = datahora;
        }

        public void StatusCliente(int status) => Status = (StatusCliente)status;

    }

}
