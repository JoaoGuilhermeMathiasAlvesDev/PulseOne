using Aplication.PulseOne.Models.Usuario;
using Dominio.PulseOne.Entiteis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.PulseOne.Logic
{
    public static class UsuarioLogic
    {
        public static void validarSenha(string senha,string confirmarSenha)
        {
            var helper = new Usuario();

            if(!helper.ConfirmaSenha(senha, confirmarSenha))
                throw new Exception("As senhas não conferem! Por gentileza, digite novamente.");

        }

        public static Usuario PrepararNovoUsuario(AdicionarUsuarioModel model)
        {
            validarSenha(model.Senha, model.ConfirmarSenhar);

            int perfil = (int)model.Perfil;
            return new Usuario(model.Email, model.Senha, perfil);
        }

        public static void AtualizarEntidade(Usuario usuarioExistente, AtualizarUsuarioModel model)
        {
            validarSenha(model.NovaSenha, model.ConfirmarSenhar);

            if((int)usuarioExistente.Perfil != (int)model.Perfil)
            {
                int perfil = (int)model.Perfil;
            }
              
            usuarioExistente.DefinirDados(model.Email, model.NovaSenha, (int)model.Perfil);
        }

        public static UsuarioModel MapearParaModel(Usuario u)
        {
            if (u is null) return null;

            return new UsuarioModel
            {
                Id = u.Id,
                Email = u.Email,
                Senha = u.Senha,
                Perfil = u.Perfil,
            };
        }
    }
}
