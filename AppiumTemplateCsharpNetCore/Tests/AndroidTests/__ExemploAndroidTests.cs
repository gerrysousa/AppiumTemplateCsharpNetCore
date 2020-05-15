using AppiumTemplateCsharpNetCore.Bases;
using AppiumTemplateCsharpNetCore.Flows;
using AppiumTemplateCsharpNetCore.Helpers;
using AppiumTemplateCsharpNetCore.Pages;
using NUnit.Framework;

namespace AppiumTemplateCsharpNetCore.Tests.AndroidTests
{
    class CadastrarUsuarioTests : TestBase
    {
        #region objetos e parametros
        [AutoInstance] __ExemploFlows exemploFlows;
       
        
        #endregion

        [Test]
        public void Test_CadastrarNovoUsuarioComSucesso()
        {
            #region Parametros
            //string cpf = GeneralHelpers.GerarCpf();
            string nomeCliente = "Cliente Automacao Cadastro";
            string celular = "99999999999";
            string emailCliente = "automacao@teste.com";
            string senhaSistema = "123qwe";

            string mensagemEsperada = "Olá Cliente Automacao Cadastro";

            #endregion

            #region Acoes
            //promoPageFlows.Pular();
            //inicialFlows.ClicarBtnAcesseSuaConta();
            //loginCpfFlows.EscreverNumeroCPFEAvancar(cpf);
            //cadastroFlows.PreencherTodosDadosCadastroConcordarExecutarScrollDownEAvancar(nomeCliente, celular, emailCliente, senhaSistema);
            //smsFlows.PreencherTokenValidartoken("999999");

            #endregion

            #region Asserts
            //string textoObtido = iniciarSimulacaoFlows.RetortarMensagemBoasVindas();

            //Assert.Multiple(() =>
            //{
            //    Assert.AreEqual(mensagemEsperada, textoObtido);
            //});

            #endregion
        }

       
    }
}