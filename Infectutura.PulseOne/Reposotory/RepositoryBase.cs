using Infectutura.PulseOne.Data;
using Infectutura.PulseOne.IRepository.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infectutura.PulseOne.Reposotory
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private readonly PulseOneContext _context;

        public RepositoryBase(PulseOneContext context)
        {
            _context = context;
        }

        public async Task Adicionar(T entity)
        {
            await _context.Set<T>().AddAsync(entity);

        }

        public Task Atualizar(T entity)
        {
            _context.Set<T>().Update(entity);
            return Task.CompletedTask;
            
        }

        public async Task<T> ObterPorId(Guid Id)
        {
            return await _context.Set<T>().FindAsync(Id);
        }

        public async Task<List<T>> ObterTodos<T>(int pagina, int tamanhoPagina) where T : class
        {
           return await (_context.Set<T>().
                Skip((pagina -1)* tamanhoPagina)
                .Take(tamanhoPagina)
                .ToListAsync());
        }

        public Task Remover(T entity)
        {
             _context.Set<T>().Remove(entity);
            return Task.CompletedTask;
        }
    }
}
