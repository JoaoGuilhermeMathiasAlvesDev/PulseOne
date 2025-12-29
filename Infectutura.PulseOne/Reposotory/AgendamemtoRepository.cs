using Dominio.PulseOne.Entiteis;
using Infectutura.PulseOne.Data;
using Infectutura.PulseOne.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infectutura.PulseOne.Reposotory
{
    public class AgendamemtoRepository : RepositoryBase<Agendamento> ,IAgendametoRepository
    {
        private readonly PulseOneContext _context;

        public AgendamemtoRepository(PulseOneContext context) : base(context) 
        {
            _context = context;
        }
    }
}
