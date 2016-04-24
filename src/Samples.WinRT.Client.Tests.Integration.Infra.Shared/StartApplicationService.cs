using Caliburn.Micro;
using LogoFX.Client.Testing.Integration;
using Samples.WinRT.Client.Presentation.Shell.ViewModels;

namespace Samples.WinRT.Client.Tests.Integration.Infra.Shared
{
    public class StartApplicationService : StartApplicationServiceBase
    {
        // ReSharper disable once RedundantOverridenMember
        protected override void RegisterFakes()
        {
            base.RegisterFakes(); 
            //TODO: add builders registration           
        }

        protected override void OnStart(object rootObject)
        {
            var shell = (ShellViewModel)rootObject;
            StructureHelper.SetRootObject(shell);
            ScreenExtensions.TryActivate(shell);            
        }
    }
}