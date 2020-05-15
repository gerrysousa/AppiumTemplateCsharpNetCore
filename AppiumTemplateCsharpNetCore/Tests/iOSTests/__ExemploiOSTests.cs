using AppiumTemplateCsharpNetCore.Bases;
using AppiumTemplateCsharpNetCore.Flows;
using AppiumTemplateCsharpNetCore.Helpers;
using AppiumTemplateCsharpNetCore.Pages;
using NUnit.Framework;

namespace AppiumTemplateCsharpNetCore.Tests.iOSTests
{
    class CadastrarUsuarioTests : TestBase
    {

        #region objetos e parametros
        [AutoInstance] __ExemploFlows exemploFlows;

        #endregion

        [Test]
        public void Test_CadastrarNovoUsuarioComSucesso()
        {

            #region Parametros and Objetos
            //string cpf = GeneralHelpers.GerarCpf();
            string nomeCliente = "Cliente Automacao Cadastro";
            string celular = "99999999999";
            string emailCliente = "automacao@teste.com";
            string senhaSistema = "123qwe";

            string mensagemEsperada = "Iremos guiá-lo em uma simulação de crédito para identificarmos as melhores ofertas para você.";

            #endregion

            #region Acoes
            //promoPageFlows.AceitarNotificacaoEPular();
            //inicialFlows.ClicarBtnAcesseSuaConta();
            //loginCpfFlows.EscreverNumeroCPFClicarOkTecladoEAvancar(cpf);
            //cadastroFlows.PreencherTodosDadosCadastroConcordarAvancar(nomeCliente, celular, emailCliente, senhaSistema);
            //smsFlows.PreencherTokenClicarOkTecladoEValidartoken("999999");

            #endregion

            #region Asserts
            //string textoObtido = iniciarSimulacaoFlows.RetortarMensagemBoasVindas();

            //Assert.Multiple(() =>
            //{
            //    Assert.AreEqual(mensagemEsperada, textoObtido);
            //    // Assert.IsTrue(existeOfertacartao);
            //});

            #endregion
        }
    }
}