using Dominio.PulseOne.Entiteis.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.PulseOne.Entiteis
{
    public class Cliente : EntityBase
    {
        public string Nome { get; set; }
        public string NumeroTelefone { get; set; }
        public string Email { get; set; }

        public Cliente( string nome,string numeroTelefone,string email)
        {
            DefinirCliente(nome,numeroTelefone,email);  
        }

        public void DefinirCliente(string nome, string numeroTelefone,string email)
        {
            if (nome == string.Empty)
                throw new ArgumentNullException("O cliente precisa ter um Nome.");

            if (numeroTelefone == string.Empty)
                throw new ArgumentNullException("O cliente precisa de um numero de telefone para contato.");

            if (email == string.Empty)
                throw new ArgumentNullException("O cliente precisa cadastrar o e-mail.");

            Nome = nome;
            NumeroTelefone += numeroTelefone;
            Email = email;
        }
    }
}
