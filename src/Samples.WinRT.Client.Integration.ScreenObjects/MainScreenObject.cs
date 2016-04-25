using Samples.WinRT.Client.ScreenObjects.Contracts;
using Samples.WinRT.Client.Tests.Integration.Infra.Core;

namespace Samples.WinRT.Client.Integration.ScreenObjects
{
    public class MainScreenObject : IMainScreenObject
    {
        public bool IsActive()
        {
            var main = StructureHelper.GetMain();
            return main.IsActive;
        }
    }
}