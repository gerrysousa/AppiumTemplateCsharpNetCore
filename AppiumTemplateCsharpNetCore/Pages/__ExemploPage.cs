using AppiumTemplateCsharpNetCore.Bases;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.PageObjects.Attributes;

namespace AppiumTemplateCsharpNetCore.Pages
{
    class __ExemploPage : PageBase
    {
        #region mapeamento
        [FindsByIOSUIAutomation(Accessibility = "Alt Message", Priority = 1)]
        [FindsByAndroidUIAutomator(Accessibility = "Alt Message", Priority = 1)]
        IWebElement elementoExemploComAccessibility;

        [FindsByIOSUIAutomation(Accessibility = "xxxxxx", Priority = 1)]
        [FindsByAndroidUIAutomator(ID = "br.com.ole.oleconsignado.staging:id/bt_next", Priority = 1)]
        IWebElement elementoExemploComId;

        [FindsByIOSUIAutomation(Accessibility = "xxxxxx", Priority = 1)]
        [FindsByAndroidUIAutomator(XPath = "//android.widget.TextView[@text='033 - Banco Santander (Brasil) S.A.']", Priority = 1)]
        IWebElement elementoExemploComXpathFiltradoPorTexto;

        [FindsByIOSUIAutomation(Accessibility = "xxxxxx", Priority = 1)]
        [FindsByAndroidUIAutomator(XPath = "(//android.widget.EditText)[1]", Priority = 1)]
        IWebElement elementoExemploComXpathRepetidosNumaPaginaFiltrado;        

        #endregion

        #region Acoes da pagina
        public void EscreverTextoNumElemento(string texto)
        {
            SendKeys(elementoExemploComId, texto);
        }
       
        public void ClicarNumElemento()
        {
            Click(elementoExemploComXpathFiltradoPorTexto);
        }

        public string ObterTextoDeUmElemento()
        {
            string texto = GetText(elementoExemploComXpathRepetidosNumaPaginaFiltrado);
            return texto;
        }

        public string ObterValorDeUmElemento()
        {
            string texto = GetValue(elementoExemploComAccessibility);
            return texto;
        }
        #endregion

    }
}
