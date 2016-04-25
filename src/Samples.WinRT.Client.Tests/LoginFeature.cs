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

        [TestMethod]
        public void NavigateToTheMainScreenWheTheLoginIsSuccessful()
        {
            var userName = "Admin";
            //TODO: replace ioc container as caliburn.micro simple container
            //throws exception on duplicate service registration
            //the convention is to use the last. that's the appropriate
            //behavior among the ioc containers. When the container is replaced
            //the following line will be restored.
            //GivenLoginSteps.SetupAuthenticatedUserWithUsername(userName);
            GivenLoginSteps.SetupLoginSuccessfullyWithUsername(userName);

            GeneralSteps.WhenIOpenTheApplication();
            LoginSteps.WhenISetTheUsernameTo(userName);
            LoginSteps.WhenILogInToTheSystem();

            MainSteps.ThenApplicationNavigatesToTheMainScreen();
        }
    }
}
