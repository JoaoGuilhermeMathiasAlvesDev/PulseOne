using Dominio.PulseOne.Entiteis;
using Dominio.PulseOne.Entiteis.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDominio
{
    public class UsuarioTest
    {
         private const string EmailValido = "teste@dominio.com";
        private const string SenhaValida = "senhaforte123";
        private const int PerfilValido = (int)PerfilEnum.Administrativo;

        [Fact]
        public void Conctrutor_DadosValidos_DeveCriarUsuarioCorretor()
        {

            var usuario = new Usuario(EmailValido,SenhaValida,PerfilValido);

            Assert.NotNull(usuario);
            Assert.Equal(EmailValido ,usuario.Email);
            Assert.Equal(SenhaValida ,usuario.Senha);
            Assert.Equal(PerfilValido,(int)usuario.Perfil);
        }

        [Fact]
        public void Conctrutor_DadoValidos_DeveAtualizarUsuarioCorretor()
        {
             var usuario = new Usuario(EmailValido, SenhaValida, PerfilValido);

            const string novoEmail = "novo.email@teste.com";
            const string novaSenha = "super_nova_senha";
            const int novoPerfil = (int)PerfilEnum.Profisional;

            usuario.DefinirDados(novoEmail, novaSenha,novoPerfil);

            Assert.NotNull(usuario);
            Assert.Equal(novoEmail,usuario.Email);
            Assert.Equal(novaSenha ,usuario.Senha);
            Assert.Equal(novoPerfil,(int)usuario.Perfil);

        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("emailsemarroba.com")]
        [InlineData("email@dominio")]
        public void Construtor_EmailInvalido_DeveLancarArgumentException(string emailInvalido)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                new Usuario(emailInvalido, SenhaValida, PerfilValido);
            });
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("12345")]
        [InlineData("123456")]
        public void Construtor_SenhaInvalido_DeveLancarArgumentException(string senhaInvalida)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                new Usuario(senhaInvalida, EmailValido, PerfilValido);
            });
        }
    }
}
