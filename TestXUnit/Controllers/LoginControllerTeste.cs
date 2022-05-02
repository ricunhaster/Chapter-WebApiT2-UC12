using Chapter.WebApi.Controllers;
using Chapter.WebApi.Interfaces;
using Chapter.WebApi.Models;
using Chapter.WebApi.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TestXUnit.Controllers
{
    
    public  class LoginControllerTeste
    {
        public int UnauthorizedOjbectResult { get; private set; }

        [Fact]
        public void LoginController_DeveRetornar_UsuarioInvalido()
        {
            //Arrange
            var fakeRepository = new Mock<IUsuarioRepository>();
            fakeRepository.Setup(x => x.Login(It.IsAny<string>(), It.IsAny<string>())).Returns((Usuario)null);

            LoginViewModel dadosLogin = new LoginViewModel();
            dadosLogin.email = "email@email.com";
            dadosLogin.senha = "1234";

            var controller = new LoginController(fakeRepository.Object);

            //Act
            
            var resultado = controller.Login(dadosLogin);

            //Assert
            Assert.IsType<UnauthorizedObjectResult>(resultado);

        }
        [Fact]
        public void LoginController_DeveRetornar_Token()
        {
            //Arrange
            var usuarioRetorno = new Usuario();
            usuarioRetorno.Email = "email@email.com";
            usuarioRetorno.Senha = "1234";

            var fakeRepository = new Mock<IUsuarioRepository>();
            fakeRepository.Setup(x => x.Login(It.IsAny<string>(), It.IsAny<string>())).Returns(usuarioRetorno);

            string issuerValidacao = "chapter.webapi";

            LoginViewModel dadosLogin = new LoginViewModel();
            dadosLogin.email = "email@email.com";
            dadosLogin.senha = "1234";

            var controller = new LoginController(fakeRepository.Object);

            //Act
            OkObjectResult resultado = (OkObjectResult)controller.Login(dadosLogin);

            string token = resultado.Value.ToString().Split(' ')[3];

            var jwtHandler = new JwtSecurityTokenHandler();
            var tokenJwt = jwtHandler.ReadJwtToken(token);

            //Assert
            Assert.Equal(issuerValidacao, tokenJwt.Issuer);
        }
    }
}
