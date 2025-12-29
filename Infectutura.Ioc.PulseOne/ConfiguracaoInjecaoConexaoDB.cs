using Infectutura.PulseOne.Data;
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
        public static void BancoDados(this IServiceCollection services, IConfiguration configuration) =>
            services.AddDbContext <PulseOneContext> (options =>
            options.UseSqlServer(configuration.GetConnectionString(configuration.GetConnectionString(""));

       
    }
}
