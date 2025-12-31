using Dominio.PulseOne.Entiteis.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.PulseOne.Models.Usuario
{
    public class AtualizarUsuarioModel
    {
        public Guid Id { get; set; }
        public string Email {  get; set; }
        public string NovaSenha { get; set; }
        public string ConfirmarSenhar { get; set; }
        public PerfilEnum Perfil { get; set; }
    }
}
