using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.PulseOne.Models.Cliente
{
    public class ClienteModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string NumeroTelefone { get; set; }
        public string Email { get; set; }

    }
}
