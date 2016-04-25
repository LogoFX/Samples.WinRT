using Attest.Fake.Builders;
using Samples.Client.Data.Contracts.Providers;

namespace Samples.WinRT.Client.Tests.Integration.Infra.Steps.Given.Contracts
{
    public interface ILoginProviderBuilderFactory
    {
        FakeBuilderBase<ILoginProvider> SetupWithUserName(string username);
        FakeBuilderBase<ILoginProvider> SetupWithSuccessfulLogin(string username);
    }
}
