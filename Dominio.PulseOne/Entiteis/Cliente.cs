using Dominio.PulseOne.Entiteis.Base;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.PulseOne.Entiteis
{
    public class Cliente : EntityBase
    {
        public string Nome { get;private set; }
        public string NumeroTelefone { get;private set; }
        public string Email { get;private set; }

        protected Cliente() { }

        public Cliente( string nome,string numeroTelefone,string email)
        {
            DefinirCliente(nome,numeroTelefone,email);  
        }

        public void DefinirCliente(string nome, string numero,string email)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentNullException("O cliente precisa ter um Nome.");

            if (string.IsNullOrWhiteSpace(numero))
                throw new ArgumentNullException("O cliente precisa de um numero de telefone para contato.");

            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentNullException("O cliente precisa cadastrar o e-mail.");

            Nome = nome;
            NumeroTelefone = numero;
            Email = email;
        }
    }
}
