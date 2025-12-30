using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.PulseOne.Entiteis.ObjectValue
{
    public class Endereco
    {
        public string Logradouro { get; private set; }
        public string Numero { get; private set; }
        public string Cidade { get; private set; }
        public string Estado { get; private set; }
        public string CEP { get; private set; }

        protected Endereco() { }
        public Endereco(string rua, string numero, string cidade, string estado, string cep)
        {
            //todo  Validações aqui
            Logradouro = rua;
            Numero = numero;
            Cidade = cidade;
            Estado = estado;
            CEP = cep;
        }


    }
}
