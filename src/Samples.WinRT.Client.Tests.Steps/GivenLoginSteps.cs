#if FAKE
using Attest.Testing.Core;
using LogoFX.Client.Testing.Contracts;
using Samples.WinRT.Client.Tests.Integration.Infra.Steps.Given.Contracts;

#endif

#if REAL
#endif

namespace Samples.WinRT.Client.Tests.Steps
{
    public static class GivenLoginSteps
    {
        public static void SetupAuthenticatedUserWithUsername(string username)
        {
#if FAKE
            var loginProviderBuilder = ScenarioHelper.Get<ILoginProviderBuilderFactory>().SetupWithUserName(username);
            ScenarioHelper.Get<IBuilderRegistrationService>().RegisterBuilder(loginProviderBuilder);
#endif

#if REAL
            //put here real Setup
#endif
        }        

        public static void SetupLoginSuccessfullyWithUsername(string username)
        {
#if FAKE
            var loginProviderBuilder =
                ScenarioHelper.Get<ILoginProviderBuilderFactory>().SetupWithSuccessfulLogin(username);
            ScenarioHelper.Get<IBuilderRegistrationService>().RegisterBuilder(loginProviderBuilder);
#endif

#if REAL
            //put here real Setup
#endif
        }
    }
}