using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using Samples.Client.Tests.Steps;
using Samples.WinRT.Client.Tests.Integration.Infra;

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

        [TestMethod]
        public void NavigateToTheMainScreenWheTheLoginIsSuccessful()
        {
            var userName = "Admin";           
            GivenLoginSteps.SetupAuthenticatedUserWithUsername(userName);
            GivenLoginSteps.SetupLoginSuccessfullyWithUsername(userName);

            GeneralSteps.WhenIOpenTheApplication();
            LoginSteps.WhenISetTheUsernameTo(userName);
            LoginSteps.WhenILogInToTheSystem();

            MainSteps.ThenApplicationNavigatesToTheMainScreen();
        }
    }
}
