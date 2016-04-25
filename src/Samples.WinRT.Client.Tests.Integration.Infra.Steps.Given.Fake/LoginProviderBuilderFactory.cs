using Attest.Fake.Builders;
using Attest.Testing.Core;
using Samples.Client.Data.Contracts.Providers;
using Samples.Client.Data.Fake.ProviderBuilders;
using Samples.WinRT.Client.Tests.Integration.Infra.Steps.Given.Contracts;

namespace Samples.WinRT.Client.Tests.Integration.Infra.Steps.Given.Fake
{
    public class LoginProviderBuilderFactory : ILoginProviderBuilderFactory
    {
        public FakeBuilderBase<ILoginProvider> SetupWithUserName(string username)
        {
            var loginProviderBuilder = ScenarioHelper.GetOrCreate(LoginProviderBuilder.CreateBuilder);
            loginProviderBuilder.WithUser(username, string.Empty);
            return loginProviderBuilder;
        }

        public FakeBuilderBase<ILoginProvider> SetupWithSuccessfulLogin(string username)
        {
            var loginProviderBuilder = ScenarioHelper.GetOrCreate(LoginProviderBuilder.CreateBuilder);
            loginProviderBuilder.WithSuccessfulLogin(username);
            return loginProviderBuilder;

        }

    }
}
