using System.Linq;
using LogoFX.Client.Modularity;
using Samples.WinRT.Client.Presentation.Shell.ViewModels;

namespace Samples.WinRT.Client.Tests.Integration.Infra.Core
{
    /// <summary>
    /// Represents structure helper which provides easier API for accessing different parts of application
    /// </summary>
    public static class StructureHelper
    {
        private static ShellViewModel _rootObject;

        /// <summary>
        /// Sets the root object which is the shell view model.
        /// </summary>
        /// <param name="rootObject">The root object.</param>
        public static void SetRootObject(ShellViewModel rootObject)
        {
            _rootObject = rootObject;
        }             

        /// <summary>
        /// Gets the root view model.
        /// </summary>
        /// <typeparam name="TRootViewModel">The type of the root view model.</typeparam>
        /// <returns>Root view model</returns>
        public static TRootViewModel GetRootViewModel<TRootViewModel>() where TRootViewModel : IRootViewModel
        {
            return GetRootViewModelInternal<TRootViewModel>();
        }

        /// <summary>
        /// Accesses the root view model.
        /// </summary>
        /// <typeparam name="TRootViewModel">The type of the root view model.</typeparam>
        public static void AccessRootViewModel<TRootViewModel>() where TRootViewModel : IRootViewModel
        {
            var shellViewModel = GetShellInternal();
            var rootViewModel = GetRootViewModelInternal<TRootViewModel>();
            shellViewModel.ActivateItem(rootViewModel);
        }

        /// <summary>
        /// Gets the shell view model.
        /// </summary>
        /// <returns>Shell view model</returns>
        public static ShellViewModel GetShell()
        {
            return GetShellInternal();
        }

        public static LoginViewModel GetLogin()
        {
            return GetShellInternal().LoginViewModel;
        }

        private static ShellViewModel GetShellInternal()
        {
            return _rootObject;
        }

        private static TRootViewModel GetRootViewModelInternal<TRootViewModel>() where TRootViewModel : IRootViewModel
        {
            var rootViewModel =
                GetShellInternal()
                    .Items.OfType<TRootViewModel>()
                    .FirstOrDefault();
            return rootViewModel;
        }
    }
}