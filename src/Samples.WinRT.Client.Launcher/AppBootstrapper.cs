using Windows.UI.Xaml.Controls;
using Caliburn.Micro;
using LogoFX.Bootstrapping;
using LogoFX.Client.Bootstrapping;
using LogoFX.Client.Bootstrapping.Adapters.SimpleContainer;
using Samples.WinRT.Client.Presentation.Shell.ViewModels;
using Solid.Practices.Middleware;

namespace Samples.WinRT.Client.Launcher
{
    public class AppBootstrapper : BootstrapperContainerBase<ExtendedSimpleContainerAdapter>.WithRootObject<ShellViewModel>
    {
        public AppBootstrapper() : base(new ExtendedSimpleContainerAdapter())
        {                                   
        }

        protected override void PrepareViewFirst(Frame rootFrame)
        {
            //Use(new RegisterNavigationServiceMiddleware(rootFrame));
            RegisterNavigationService(rootFrame);            
        }
        
        private void RegisterNavigationService(Frame rootFrame, bool treatViewAsLoaded = false, bool cacheViewModels = false)
        {
            INavigationService navigationService = cacheViewModels ? new CachingFrameAdapter(rootFrame, treatViewAsLoaded) : new FrameAdapter(rootFrame, treatViewAsLoaded);
            Registrator.RegisterInstance(navigationService);            
        }
    }

    // ReSharper disable once UnusedMember.Local -- This middleware uses Frame object which is still not available during Configure phase...
    class RegisterNavigationServiceMiddleware : 
        IMiddleware<IBootstrapperWithContainerRegistrator>
    {
        private readonly Frame _rootFrame;
        private readonly bool _treatViewAsLoaded;
        private readonly bool _cacheViewModels;

        public RegisterNavigationServiceMiddleware(Frame rootFrame, bool treatViewAsLoaded = false, bool cacheViewModels = false)
        {
            _rootFrame = rootFrame;
            _treatViewAsLoaded = treatViewAsLoaded;
            _cacheViewModels = cacheViewModels;
        }

        public IBootstrapperWithContainerRegistrator 
            Apply(IBootstrapperWithContainerRegistrator @object)
        {
            INavigationService navigationService = _cacheViewModels ? new CachingFrameAdapter(_rootFrame, _treatViewAsLoaded) : new FrameAdapter(_rootFrame, _treatViewAsLoaded);
            @object.Registrator.RegisterInstance(navigationService);
            return @object;
        }
    }
}
