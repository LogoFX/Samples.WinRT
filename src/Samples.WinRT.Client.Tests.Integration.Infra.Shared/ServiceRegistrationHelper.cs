using Attest.Testing.Core;
using LogoFX.Client.Testing.Contracts;
using Samples.WinRT.Client.Integration.ScreenObjects;
using Samples.WinRT.Client.ScreenObjects.Contracts;

namespace Samples.WinRT.Client.Tests.Integration.Infra.Shared
{
    public static class ServiceRegistrationHelper
    {
        public static void RegisterIntegrationObjects()
        {
            ScenarioHelper.Add(new StartApplicationService(), typeof(IStartApplicationService));
            ScenarioHelper.Add(new LoginScreenObject(), typeof(ILoginScreenObject));
        }
    }
}
