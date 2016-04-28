using Samples.WinRT.Client.Tests.Contracts.ScreenObjects;
using Samples.WinRT.Client.Tests.Integration.Infra.Core;

namespace Samples.WinRT.Client.Tests.Integration.ScreenObjects
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