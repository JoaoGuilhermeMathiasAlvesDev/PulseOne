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
            // Obtém o Assembly (o projeto compilado) onde a RepositoryBase está. 
            // Isso permite ao código "escanear" todos os tipos existentes nesse projeto.
            var asemblyRepository = typeof(RepositoryBase<>).Assembly;

            // Busca no projeto todos os tipos que são classes concretas 
            // (não abstratas) e que seguem a convenção de nomenclatura terminando em "Repository".
            var repositorios = asemblyRepository.GetTypes()
                .Where(r => r.IsClass && !r.IsAbstract && r.Name.EndsWith("Repository"));

            // Para cada classe encontrada, busca-se uma interface 
            // que siga o contrato "I" + NomeDaClasse (ex: ClienteRepository -> IClienteRepository).
            foreach (var repository in repositorios)
            {

                var interfaceType = repository.GetInterfaces()
                    .FirstOrDefault(i => i.Name == $"I{repository.Name}");

                if (interfaceType != null)
                {
                    // Registra com tempo de vida 'Scoped' (uma instância por requisição HTTP).
                    services.AddScoped(interfaceType, repository);
                }
            }

            services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();

        }



    }
}
