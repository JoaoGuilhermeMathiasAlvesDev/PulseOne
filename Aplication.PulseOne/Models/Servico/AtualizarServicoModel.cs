using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.PulseOne.Models.Servico
{
    public class AtualizarServicoModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public double preco { get; set; }
        public int Duracao { get; set; }
    }
}
