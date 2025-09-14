using Dominio.PulseOne.Entiteis.Base;
using Dominio.PulseOne.Entiteis.Enum;
using System;

namespace Dominio.PulseOne.Entiteis
{
    public class Usuario : EntityBase
    {
        public string Email { get;private set; }
        public string Senha {  get;private set; }
        public PerfilEnum Perfil { get; set; }

        public Usuario(string email,string senha,int perfilEnum)
        {
            
        }

        public void DefinirDados(string nome, string email, string senha, int perfilInt)
        {

            if (string.IsNullOrWhiteSpace(email) || !email.Contains("@"))
                throw new ArgumentException("Email inválido.");

            if (string.IsNullOrWhiteSpace(senha) || senha.Length < 6)
                throw new ArgumentException("Senha deve ter pelo menos 6 caracteres.");

            Email = email;
            Senha = senha; // Em produção, aplicar hash!
            Perfil = ConverterPerfil(perfilInt);
        }

        private PerfilEnum ConverterPerfil(int valor)
        {
            if (!System.Enum.IsDefined(typeof(PerfilEnum), valor))
                throw new ArgumentException("Perfil não reconhecido.");

            return (PerfilEnum)valor;
        }
    }
}
