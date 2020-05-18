using AppiumTemplateCsharpNetCore.Bases;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.PageObjects.Attributes;

namespace AppiumTemplateCsharpNetCore.Pages
{
    class __ExemploLoginPage : PageBase
    {
        #region mapeamento
        [FindsByIOSUIAutomation(XPath = "//XCUIElementTypeTextField[@value='Username']", Priority = 1)]
        [FindsByAndroidUIAutomator(Accessibility = "Username Input Field", Priority = 1)]
        IWebElement usernameField;

        [FindsByIOSUIAutomation(XPath= "//XCUIElementTypeSecureTextField[@value='Password']", Priority = 1)]
        [FindsByAndroidUIAutomator(Accessibility = "Password Input Field", Priority = 1)]
        IWebElement passwordField;

        [FindsByIOSUIAutomation(Accessibility = "Login", Priority = 1)]
        [FindsByAndroidUIAutomator(Accessibility = "Login Button", Priority = 1)]
        IWebElement btnLogin;

        [FindsByIOSUIAutomation(XPath = "(//XCUIElementTypeStaticText)[1]", Priority = 1)]
        [FindsByAndroidUIAutomator(Accessibility = "Alt Message", Priority = 1)]
        IWebElement message;

        #endregion

        #region Acoes da pagina
        public void PreencherNome(string username)
        {
            SendKeys(usernameField, username);
        }
        public void PreencherSenha(string password)
        {
            SendKeys(passwordField, password);
        }
        public void ClicarBtnLogin()
        {
            Click(btnLogin);
        }
        public string ObterTextoMensagem()
        {
            string texto = GetText(message);
            return texto;
        }

        #endregion
    }
}
