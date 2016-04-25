using Attest.Testing.Core;
using LogoFX.Client.Testing.Contracts;
using Samples.WinRT.Client.Integration.ScreenObjects;
using Samples.WinRT.Client.ScreenObjects.Contracts;
#if FAKE
using Samples.WinRT.Client.Tests.Integration.Infra.Steps.Given.Contracts;
using Samples.WinRT.Client.Tests.Integration.Infra.Steps.Given.Fake;
#endif

namespace Samples.WinRT.Client.Tests.Integration.Infra.Shared
{
    public static class ServiceRegistrationHelper
    {
        public static void RegisterIntegrationObjects()
        {
            ScenarioHelper.Add(new StartApplicationService(), typeof(IStartApplicationService));
            ScenarioHelper.Add(new LoginScreenObject(), typeof(ILoginScreenObject));
            ScenarioHelper.Add(new MainScreenObject(), typeof (IMainScreenObject));
#if FAKE
            ScenarioHelper.Add(new LoginProviderBuilderFactory(), typeof(ILoginProviderBuilderFactory));
#endif
        }
    }
}
