using Attest.Fake.Builders;
using LogoFX.Client.Testing.Contracts;

namespace Samples.WinRT.Client.Tests.Integration.Infra
{
    public class BuilderRegistrationService : StepsBase, IBuilderRegistrationService
    {
        void IBuilderRegistrationService.RegisterBuilder<TService>(FakeBuilderBase<TService> builder)
        {
            this.RegisterBuilder<TService>(builder);
        }
    }
}