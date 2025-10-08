using Dominio.PulseOne.Entiteis.Base;
using Dominio.PulseOne.Entiteis.Enum;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.PulseOne.Entiteis
{
    public class Recepcao : EntityBase
    {
        public Guid AtenimentoId { get; private set; }
        public Atendimento Atendimento { get; private set; }

        public FormaPagamentoEnum FormaPagamento { get; private set; }

        public double ValorTotal { get; private set; }

        public double Troco { get; private set; }


        public Recepcao(Guid atendimento)
        {
            DefinirAtendimento(atendimento);
        }

        public void DefinirAtendimento(Guid atendimentoId)
        {
            if (atendimentoId == Guid.Empty) throw new ArgumentNullException("Selecione Uma Atendimento Finalizado.");

            AtenimentoId = atendimentoId;
        }

        public FormaPagamentoEnum FormaDePagamento(int formaPagamento)
        {
            if (!System.Enum.IsDefined(typeof(FormaPagamentoEnum), formaPagamento))
                throw new ArgumentException("Forma de Pagamento não reconhecida.");

            return (FormaPagamentoEnum)formaPagamento;
        }

        public (double total, double Troco) CalcularTrocoECValores(double valorPago, int formaDePagmento)
        {

            var troco = 0.0;

            if (Atendimento is null)
                throw new InvalidOperationException("Precisa ter Uma Atenidmento.");


            var totalDoAtendimento = this.Atendimento.ValorTotla();

            if (formaDePagmento == ((int)FormaPagamentoEnum.Dinehiro))
            {
                if (valorPago < totalDoAtendimento)
                    throw new ArgumentException("O Valor do Pagmento tem que ser maior que Total do Atendimento");

                troco = valorPago - totalDoAtendimento;
            }

            else 
            {
                if (valorPago != totalDoAtendimento)
                {
                    throw new ArgumentException($"Para esta forma de pagamento ({(FormaPagamentoEnum)formaDePagmento}), o valor pago ({valorPago:N2}) deve ser exatamente igual ao Total do Atendimento ({totalDoAtendimento:N2}).");
                }
            }
            this.ValorTotal = totalDoAtendimento;
            this.Troco = troco;

            return (ValorTotal, Troco);
        }
    }
}
