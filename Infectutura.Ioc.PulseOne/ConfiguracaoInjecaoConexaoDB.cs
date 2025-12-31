using Aplication.PulseOne.Servicos;
using Infectutura.PulseOne.Data;
using Infectutura.PulseOne.IRepository.Base;
using Infectutura.PulseOne.IRepository.IUnitOfWork;
using Infectutura.PulseOne.Reposotory;
using Infectutura.PulseOne.Reposotory.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Infectutura.Ioc.PulseOne
{
    public static class ConfiguracaoInjecaoConexaoDB
    {
        public static void BancoDados(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<PulseOneContext>(options =>
            options.UseSqlServer(
            configuration.GetConnectionString("DataBase"), x => x.MigrationsAssembly("Apresentation.PulseOne")));
        }

        public static void InjeicaoDeIdependenciaRepository(this IServiceCollection services, IConfiguration configuration)
        {
            var asemblyRepository = typeof(RepositoryBase<>).Assembly;

            var repositorios = asemblyRepository.GetTypes()
                .Where(r => r.IsClass && !r.IsAbstract && r.Name.EndsWith("Repository"));

            foreach (var repository in repositorios)
            {

                var interfaceType = repository.GetInterfaces()
                    .FirstOrDefault(i => i.Name == $"I{repository.Name}");

                if (interfaceType != null)
                {
                    services.AddScoped(interfaceType, repository);
                }
            }

            services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();

        }
        public static void InjeicaoDeIdependenciaServices(this IServiceCollection services,IConfiguration configuration)
        {
            var asemblyRepository = typeof(UsuarioServices).Assembly;

            var servicos = asemblyRepository.GetTypes().
                Where(s => s.IsClass && !s.IsAbstract && s.Name.EndsWith("Services")); 

            foreach(var servico in servicos)
            {
                var interfaceType = servico.GetInterfaces().FirstOrDefault(i => i.Name == $"I{servico.Name}");

                if (interfaceType != null)
                {
                    services.AddScoped(interfaceType, servico);
                }
            }

        }

    }
}
