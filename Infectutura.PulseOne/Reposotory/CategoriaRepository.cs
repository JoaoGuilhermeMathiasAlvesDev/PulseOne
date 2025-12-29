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
    public class CategoriaRepository : RepositoryBase<Categoria>,ICategoriaRepostory
    {
        private readonly PulseOneContext _context;

        public CategoriaRepository(PulseOneContext context) : base(context) 
        {
            _context = context;
        }
    }
}
