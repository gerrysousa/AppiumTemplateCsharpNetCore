using AppiumTemplateCsharpNetCore.Pages;

namespace AppiumTemplateCsharpNetCore.Flows
{
    public class __ExemploLoginFlows
    {
        __ExemploLoginPage exemploLoginPage = new __ExemploLoginPage();

        public void FazerLogin(string username, string password)
        {
            exemploLoginPage.PreencherNome(username);
            exemploLoginPage.PreencherSenha(password);
            exemploLoginPage.ClicarBtnLogin();
        }

        public string ObterMensagemLogin()
        {
            string texto = exemploLoginPage.ObterTextoMensagem();
            return texto;
        }
    }
}
