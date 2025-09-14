using Dominio.PulseOne.Entiteis.Base;
using Dominio.PulseOne.Entiteis.ObjectValue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.PulseOne.Entiteis
{ 
    public class Estabelecimento : EntityBase
    {
        public string Nome { get;private set; }
        public Endereco Endereco { get;private set; }
        public ICollection<Funcionario> Funcionarios { get; private set; }


        public Estabelecimento(string nome, Endereco endereco)
        {
            Funcionarios = new List<Funcionario>();

            DefinirDados(nome, endereco);
        }

        public void DefinirDados(string nome, Endereco endereco)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("Nome do estabelecimento não pode ser vazio.");

            if (endereco == null)
                throw new ArgumentNullException(nameof(endereco), "Endereço é obrigatório.");

            Nome = nome;
            Endereco = endereco;
        }

        public void AdicionarFuncionario( Funcionario funcionario)
        {
            if (funcionario is null)
                throw new ArgumentException(nameof(funcionario));

            if (Funcionarios.Any(f => f.Id == funcionario.Id))
                throw new ArgumentException("Funcionario ja vinculado ao estabelecimento");

            Funcionarios.Add(funcionario);
        }

    }
}
