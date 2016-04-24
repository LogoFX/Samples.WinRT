using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using Samples.WinRT.Client.Tests.Integration.Infra;
using Samples.WinRT.Client.Tests.Steps;

namespace Samples.WinRT.Client.Tests
{
    [TestClass]
    public class LoginFeature : IntegrationTestsBaseWithActivation
    {
        [TestMethod]
        public void LoginScreenIsDisplayedFirst()
        {
            GeneralSteps.WhenIOpenTheApplication();

            LoginSteps.ThenTheLoginScreenIsDisplayed();
        }
    }
}
