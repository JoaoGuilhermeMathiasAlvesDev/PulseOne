using Dominio.PulseOne.Entiteis.Base;
using Dominio.PulseOne.Entiteis.Enum;
using System;
using System.Text.RegularExpressions;

namespace Dominio.PulseOne.Entiteis
{
    public class Usuario : EntityBase
    {
        public string Email { get;private set; }
        public string Senha {  get;private set; }
        public PerfilEnum Perfil { get; set; }

        public Usuario(string email,string senha,int perfilEnum)
        {
            DefinirDados(email,senha, perfilEnum);
        }

        private const string EmailRegex = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";


        public void DefinirDados( string email, string senha, int perfilInt)
        {

            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("Email inválido.");

            if(!Regex.IsMatch(email,EmailRegex))
                throw new ArgumentException("Email inválido.");

            if (string.IsNullOrWhiteSpace(senha) || senha.Length < 6)
                throw new ArgumentException("Senha deve ter pelo menos 6 caracteres.");

            Email = email;
            Senha = senha;
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
