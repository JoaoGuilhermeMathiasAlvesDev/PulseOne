using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.PulseOne.Entiteis.Base
{
    public class EntityBase
    {
        public Guid Id { get;private set; }
        public DateTime CreateDate { get; private set; }
        public DateTime? UpdateDate { get; private set; }

        public EntityBase()
        {
            Id = Guid.NewGuid();
            CreateDate = DateTime.Now;
        }

        public void AddDateUpdate()
        {
            UpdateDate = DateTime.Now;
        }
    }
}
