using Infectutura.PulseOne.Data;
using Infectutura.PulseOne.IRepository.IUnitOfWork;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infectutura.PulseOne.Reposotory.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly PluseOneContext _context;
        private IDbContextTransaction _transaction;

        public UnitOfWork(PluseOneContext context)
        {
            _context = context;
        }

        public async Task BeginTransactionAsync()
        {
            if (_transaction == null)
            {
                _transaction = await _context.Database.BeginTransactionAsync();
            }

        }

        public async Task CommitTransactionAsync()
        {
            try
            {
                await _context.SaveChangesAsync();

                if (_transaction != null)
                {
                    await _transaction.CommitAsync();
                }
            }
            catch
            {
                Rollback();

                throw;
            }
            finally
            {
                DisposeTransaction();
            }
        }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        private void DisposeTransaction()
        {
            _transaction?.Dispose();
        }

        public void Dispose()
        {
            DisposeTransaction();
            _context.Dispose();
        }

        public void Rollback()
        {

            if (_transaction != null)
            {
                _transaction.Rollback();
                DisposeTransaction();
            }

        }
    }
}
