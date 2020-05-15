using AppiumTemplateCsharpNetCore.Pages;

namespace AppiumTemplateCsharpNetCore.Flows
{
    public class __ExemploFlows
    {
        __ExemploPage exemploPage = new __ExemploPage();
        
        public void FluxoQueExecuta2PassosComParametro(string parametroRecebido)
        {
            exemploPage.EscreverTextoNumElemento(parametroRecebido);
            exemploPage.ClicarNumElemento();
        }

        public string FluxoQueExecuta2PassosSemParametroERetornaTexto()
        {
            exemploPage.ClicarNumElemento();
            string texto = exemploPage.ObterTextoDeUmElemento();

            return texto;
        }

        public void FluxoQueExecuta4PassosComParametro(string parametroRecebido)
        {
            exemploPage.EscreverTextoNumElemento(parametroRecebido);
            exemploPage.ObterTextoDeUmElemento();
            exemploPage.ObterValorDeUmElemento();
            exemploPage.ClicarNumElemento();
        }

        public void FluxoQueExecuta5PassosCom2Parametros(string parametroRecebido, string parametroRecebido2)
        {
            exemploPage.EscreverTextoNumElemento(parametroRecebido);
            exemploPage.EscreverTextoNumElemento(parametroRecebido2);
            exemploPage.ObterTextoDeUmElemento();
            exemploPage.ObterValorDeUmElemento();
            exemploPage.ClicarNumElemento();
        }

    }
}
