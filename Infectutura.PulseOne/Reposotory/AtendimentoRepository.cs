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
    public class AtendimentoRepository : RepositoryBase<Atendimento>,IAtentendimentoRepository
    {
        private readonly PulseOneContext _context;

        public AtendimentoRepository(PulseOneContext context) : base(context) 
        {
            _context = context;
        }
    }
}
