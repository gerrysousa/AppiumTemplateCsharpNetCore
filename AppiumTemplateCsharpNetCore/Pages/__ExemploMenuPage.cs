using AppiumTemplateCsharpNetCore.Bases;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.PageObjects.Attributes;

namespace AppiumTemplateCsharpNetCore.Pages
{
    class __ExemploMenuPage : PageBase
    {
        #region mapeamento
        [FindsByIOSUIAutomation(Accessibility = "Login", Priority = 1)]
        [FindsByAndroidUIAutomator(XPath = "//android.widget.TextView[@text='Login Page']", Priority = 1)]
        IWebElement btnLoginPage;

        [FindsByIOSUIAutomation(XPath = "//XCUIElementTypeButton[@name='More']", Priority = 1)]
        [FindsByAndroidUIAutomator(XPath = "//android.widget.ImageButton", Priority = 1)]
        IWebElement btnMenu;

       
        #endregion

        #region Acoes da pagina
        public void ClicarBtnLoginPage()
        {
            Click(btnLoginPage);
        }

        public void ClicarBtnMenu()
        {
            Click(btnMenu);
        }
        #endregion

    }
}
