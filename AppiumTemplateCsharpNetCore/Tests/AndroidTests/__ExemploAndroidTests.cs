using AppiumTemplateCsharpNetCore.Bases;
using AppiumTemplateCsharpNetCore.Flows;
using AppiumTemplateCsharpNetCore.Helpers;
using AppiumTemplateCsharpNetCore.Pages;
using NUnit.Framework;
using UITestNetCore.Helpers;

namespace AppiumTemplateCsharpNetCore.Tests.AndroidTests
{
    class CadastrarUsuarioTests : TestBase
    {
        #region objetos e parametros
        [AutoInstance] __ExemploLoginFlows loginFlows;
        [AutoInstance] __ExemploMenuFlows menuFlows;

        #endregion

        [Test]
        public void Test_FazerLoginComSucesso()
        {
            #region Parametros
            string username = "admin";
            string password = "password";
            string mensagemEsperada = "You are logged on as admin";

            #endregion

            #region Acoes
            menuFlows.AcessarLogin();
            loginFlows.FazerLogin(username, password);

            #endregion

            #region Asserts
            string textoObtido = loginFlows.ObterMensagemLogin();
            Assert.AreEqual(textoObtido, mensagemEsperada);
            #endregion
        }

        [Test]
        public void Test_FazerLoginInvalido()
        {
            #region Parametros
            string username = "teste123";
            string password = "teste123";
            string mensagemEsperada = "You gave me the wrong username and password";

            #endregion

            #region Acoes
            menuFlows.AcessarLogin();
            loginFlows.FazerLogin(username, password);

            #endregion

            #region Asserts
            string textoObtido = loginFlows.ObterMensagemLogin();
            Assert.AreEqual(textoObtido, mensagemEsperada);
            #endregion
        }
       
    }
}