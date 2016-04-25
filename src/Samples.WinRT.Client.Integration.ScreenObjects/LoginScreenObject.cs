using Samples.WinRT.Client.ScreenObjects.Contracts;
using Samples.WinRT.Client.Tests.Integration.Infra.Core;

namespace Samples.WinRT.Client.Integration.ScreenObjects
{
    public class LoginScreenObject : ILoginScreenObject
    {
        public bool IsActive()
        {
            var loginViewModel = StructureHelper.GetLogin();
            return loginViewModel.IsActive;
        }

        public void SetUsername(string username)
        {
            var loginViewModel = StructureHelper.GetLogin();
            loginViewModel.UserName = username;
        }

        public void Login()
        {
            var loginViewModel = StructureHelper.GetLogin();
            loginViewModel.LoginCommand.Execute(null);
        }
    }
}
