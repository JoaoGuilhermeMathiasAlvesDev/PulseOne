using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infectutura.PulseOne.IRepository.IUnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        // Parte dos repositories
        IAgendametoRepository Agendamentos { get; }
        IAtentendimentoRepository Atendimentos { get; }
        ICategoriaRepostory Categorias { get; }
        IClienteRepository Clientes { get; }
        IEstabelecimentoRepository Estabelecimentos { get; }
        IFinancerioRepository Financeiros { get; }
        IFuncionarioRepository Funcionarios { get; }
        IProdutoRepository Produtos { get; }
        IProfissionalRepository Profissionais { get; }
        IRecepcaoRepository Recepcoes { get; }
        IServicoRepository Servicos { get; }
        IUsuarioRepository Usuarios { get; }

        Task BeginTransactionAsync();
        Task CommitTransactionAsync();
        Task<int> CompleteAsync();
        void Rollback();
    }
}
