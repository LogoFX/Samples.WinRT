using Attest.Testing.Core;
using LogoFX.Client.Testing.Contracts;

namespace Samples.WinRT.Client.Tests.Integration.Infra.Shared
{
    public static class ServiceRegistrationHelper
    {
        public static void RegisterIntegrationObjects()
        {
            ScenarioHelper.Add(new StartApplicationService(), typeof(IStartApplicationService));
        }
    }
}
