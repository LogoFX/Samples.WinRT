using LogoFX.Client.Bootstrapping;
using LogoFX.Client.Bootstrapping.Adapters.WinRTContainer;
using Samples.WinRT.Client.Presentation.Shell.ViewModels;

namespace Samples.WinRT.Client.Tests.Integration.Infra.Shared
{
    public class TestBootstrapper : BootstrapperContainerBase<WinRTContainerAdapter>
        .WithRootObject<ShellViewModel>
    {
        public TestBootstrapper() :
            base(new WinRTContainerAdapter(), new BootstrapperCreationOptions
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