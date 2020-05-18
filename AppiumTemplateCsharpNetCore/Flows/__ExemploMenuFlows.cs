using AppiumTemplateCsharpNetCore.Pages;

namespace AppiumTemplateCsharpNetCore.Flows
{
    public class __ExemploMenuFlows
    {
        __ExemploMenuPage exemploMenuPage = new __ExemploMenuPage();

        public void AcessarLogin()
        {
            exemploMenuPage.ClicarBtnMenu();
            exemploMenuPage.ClicarBtnLoginPage();
        }       
    }
}
