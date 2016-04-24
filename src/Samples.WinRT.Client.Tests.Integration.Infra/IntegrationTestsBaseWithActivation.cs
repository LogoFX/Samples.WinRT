using Attest.Testing.Core;
using Caliburn.Micro;
using LogoFX.Client.Bootstrapping.Adapters.WinRTContainer;
using LogoFX.Client.Testing.Contracts;
using Samples.WinRT.Client.Presentation.Shell.ViewModels;
using Samples.WinRT.Client.Tests.Integration.Infra.Shared;

namespace Samples.WinRT.Client.Tests.Integration.Infra
{
    public abstract class IntegrationTestsBaseWithActivation :
        IntegrationTestsBase<WinRTContainerAdapter, ShellViewModel, TestBootstrapper>
    {               
        protected override ShellViewModel CreateRootObjectOverride(ShellViewModel rootObject)
        {
            ScreenExtensions.TryActivate(rootObject);
            return rootObject;
        }

        protected override void SetupOverride()
        {
            ServiceRegistrationHelper.RegisterIntegrationObjects();
            ScenarioHelper.Add(new BuilderRegistrationService(), typeof(IBuilderRegistrationService));
        }

        protected override void OnBeforeTeardown()
        {
            base.OnBeforeTeardown();
            TestHelper.BeforeTeardown();
        }

        protected override void OnAfterTeardown()
        {
            base.OnAfterTeardown();
            TestHelper.AfterTeardown();
        }
    }
}