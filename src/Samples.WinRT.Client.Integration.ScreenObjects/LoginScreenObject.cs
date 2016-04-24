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
    }
}
