using Aplication.PulseOne.Models.Servico;
using Dominio.PulseOne.Entiteis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.PulseOne.Validation
{
    public static class ServicoLogic
    {

        public static void ValidaModel(string nome, Double preco)
        {
            if (string.IsNullOrEmpty(nome) || preco <= 0)
                throw new ArgumentException("Todos os campos tem que ser preenchido.");
        }

        public static Servico AdicionarDados(AdicionarServicoModel model)
        {
            ValidaModel(model.Nome,model.preco);

            var adiconar = new Servico(model.Nome,model.preco);

            if(model.Duracao > 0)
            {
                adiconar.definirTempo(model.Duracao);
            }

            return adiconar;
        }

        public static void AtualizarDados(Servico servicoExistente, AtualizarServicoModel model)
        {
            ValidaModel(model.Nome, model.preco);

            if(model.Duracao > 0 && model.Duracao != servicoExistente.Duracao)
            {
                servicoExistente.definirTempo(model.Duracao);
            }

            servicoExistente.DefinirSerivco(model.Nome, model.preco);
        }

        public  static ServicoModel MapearParaModel(Servico x)
        {
            if (x is null) return null;
            return new ServicoModel
            {
                Id = x.Id,
                Nome = x.Nome,
                Preco = x.Preco,
                Duracao = x.Duracao,
            };
        }
    }
}
