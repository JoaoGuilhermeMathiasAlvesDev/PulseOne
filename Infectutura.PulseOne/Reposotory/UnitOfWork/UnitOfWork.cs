using Dominio.PulseOne.Entiteis;
using Infectutura.PulseOne.Data;
using Infectutura.PulseOne.IRepository;
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
        private readonly PulseOneContext _context;
        private IDbContextTransaction _transaction;

        public IAgendametoRepository Agendamentos { get; private set; }
        public IAtentendimentoRepository Atendimentos { get; private set; }
        public ICategoriaRepostory Categorias { get; private set; }
        public IClienteRepository Clientes { get; private set; }
        public IEstabelecimentoRepository Estabelecimentos { get; private set; }
        public IFinancerioRepository Financeiros { get; private set; } 
        public IFuncionarioRepository Funcionarios { get; private set; }
        public IProdutoRepository Produtos { get; private set; }
        public IProfissionalRepository Profissionais { get; private set; }
        public IRecepcaoRepository Recepcoes { get; private set; }
        public IServicoRepository Servicos { get; private set; }
        public IUsuarioRepository Usuarios { get; private set; }

        public UnitOfWork(PulseOneContext context)
        {
            _context = context;
            Agendamentos = new AgendamemtoRepository(_context);
            Atendimentos = new AtendimentoRepository(_context);
            Categorias = new CategoriaRepository(_context);
            Clientes = new ClienteRepository(_context);
            Estabelecimentos = new EstabelecimentoRepository(_context);
            Financeiros = new FinanceiroRepository(_context);
            Funcionarios = new FuncionarioRepository(_context);
            Produtos = new ProdutoRepository(_context);
            Profissionais = new ProfissionalRepository(_context);
            Recepcoes = new RecepcaoRepository(_context);
            Servicos = new ServicoRepository(_context);
            Usuarios = new UsuarioRepository(_context);
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
