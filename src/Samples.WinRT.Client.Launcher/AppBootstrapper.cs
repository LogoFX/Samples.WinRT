using Windows.UI.Xaml.Controls;
using Caliburn.Micro;
using LogoFX.Bootstrapping;
using LogoFX.Client.Bootstrapping;
using LogoFX.Client.Bootstrapping.Adapters.WinRTContainer;
using Samples.WinRT.Client.Presentation.Shell.ViewModels;
using Solid.Practices.IoC;
using Solid.Practices.Middleware;

namespace Samples.WinRT.Client.Launcher
{
    public class AppBootstrapper : BootstrapperContainerBase<WinRTContainerAdapter, WinRTContainer>.WithRootObject<ShellViewModel>
    {
        private static readonly WinRTContainer _iocContainer = new WinRTContainer();       

        public AppBootstrapper() : base(_iocContainer, c => new WinRTContainerAdapter(c))
        {            
        }

        protected override void PrepareViewFirst(Frame rootFrame)
        {
            Use(new RegisterNavigationServiceMiddleware<WinRTContainerAdapter>(rootFrame));
            //RegisterNavigationService(rootFrame);            
        }

        // ReSharper disable once UnusedMember.Local -- Still under debugging
        private void RegisterNavigationService(Frame rootFrame, bool treatViewAsLoaded = false, bool cacheViewModels = false)
        {
            INavigationService navigationService = cacheViewModels ? new CachingFrameAdapter(rootFrame, treatViewAsLoaded) : new FrameAdapter(rootFrame, treatViewAsLoaded);
            _iocContainer.RegisterInstance(typeof(INavigationService), null, navigationService);
        }
    }

    class RegisterNavigationServiceMiddleware<TIocContainerAdapter> : 
        IMiddleware<IBootstrapperWithContainerAdapter<TIocContainerAdapter>>
        where TIocContainerAdapter : IIocContainer
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

        public IBootstrapperWithContainerAdapter<TIocContainerAdapter> 
            Apply(IBootstrapperWithContainerAdapter<TIocContainerAdapter> @object)
        {
            INavigationService navigationService = _cacheViewModels ? new CachingFrameAdapter(_rootFrame, _treatViewAsLoaded) : new FrameAdapter(_rootFrame, _treatViewAsLoaded);
            @object.ContainerAdapter.RegisterInstance(navigationService);
            return @object;
        }
    }
}
