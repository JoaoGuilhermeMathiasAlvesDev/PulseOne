using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infectutura.PulseOne.IRepository.IUnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        // Parte dos repository 



        Task BeginTransactionAsync();
        Task CommitTransactionAsync();
        Task<int> CompleteAsync();
        void Rollback();
    }
}
