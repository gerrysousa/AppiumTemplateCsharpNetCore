using AppiumTemplateCsharpNetCore.Bases;
using AppiumTemplateCsharpNetCore.Flows;
using AppiumTemplateCsharpNetCore.Helpers;
using AppiumTemplateCsharpNetCore.Pages;
using NUnit.Framework;


namespace AppiumTemplateCsharpNetCore.Tests
{
    class __ExemploTests : TestBase
    {
        //[Test]
        public void Test_SimplesComFlows()
        {
            #region Parametros and Objetos
            __ExemploFlows exemploFlows = new __ExemploFlows();

            string parametro1 = "parametro1_user";
            string parametro2 = "parametro1_user";

            string mensagemEsperada = "Testes em andamento!!!";
            string mensagemEsperada2 = "Testes executado com sucesso!!!";

            #endregion

            #region Acoes
            exemploFlows.FluxoQueExecuta5PassosCom2Parametros(parametro1, parametro2);
            string retorto1 = exemploFlows.FluxoQueExecuta2PassosSemParametroERetornaTexto();
            #endregion

            #region Asserts

            Assert.Multiple(() =>
            {
                Assert.AreEqual(mensagemEsperada, retorto1);
                //Assert.AreEqual(mensagemEsperada2, retorto2);
            });

            #endregion
        }


       // [Test]
        public void Test_SimplesSemUtilizarFlows()
        {
            #region Parametros and Objetos
            __ExemploPage exemploPage = new __ExemploPage();

            string parametro1 = "parametro1_user";
            string parametro2 = "parametro1_user";

            string mensagemEsperada = "Testes em andamento!!!";
            string mensagemEsperada2 = "Testes executado com sucesso!!!";

            #endregion

            #region Acoes
            exemploPage.EscreverTextoNumElemento(parametro1);
            exemploPage.EscreverTextoNumElemento(parametro2);
            string retorto1 = exemploPage.ObterTextoDeUmElemento();
            exemploPage.ClicarNumElemento();
            string retorto2 = exemploPage.ObterValorDeUmElemento();

            #endregion

            #region Asserts

            Assert.Multiple(() =>
            {
                Assert.AreEqual(mensagemEsperada, retorto1);
                Assert.AreEqual(mensagemEsperada2, retorto2);
            });

            #endregion
        }


    }
}
