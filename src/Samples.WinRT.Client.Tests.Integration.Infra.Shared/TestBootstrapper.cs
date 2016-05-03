using LogoFX.Client.Bootstrapping;
using LogoFX.Client.Bootstrapping.Adapters.SimpleContainer;
using Samples.WinRT.Client.Presentation.Shell.ViewModels;

namespace Samples.WinRT.Client.Tests.Integration.Infra.Shared
{
    public class TestBootstrapper : TestBootstrapperContainerBase<ExtendedSimpleContainerAdapter>
        .WithRootObject<ShellViewModel>
    {
        public TestBootstrapper() :
            base(new ExtendedSimpleContainerAdapter(), new BootstrapperCreationOptions
            {
                UseApplication = false,
                ReuseCompositionInformation = true
            })
        {
            
        }

        public override string[] Prefixes
        {
            get
            {
                return new[] { "Samples.WinRT.Client.Presentation", "Samples.Client.Model", "Samples.Client.Data" };
            }
        }
    }
}