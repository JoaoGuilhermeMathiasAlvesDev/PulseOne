using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infectutura.PulseOne.IRepository.Base
{
    public interface IRepositoryBase<T> where T : class
    {
        Task Adiconionar(T entity);
        Task Atualizar(T entity);
        Task<T> ObterPorId(Guid Id);
        Task<List<T>> ObterTodos<T>(int pagina, int tamanhoPagina) where T : class;
        Task Remover(T entity);
    }
}
