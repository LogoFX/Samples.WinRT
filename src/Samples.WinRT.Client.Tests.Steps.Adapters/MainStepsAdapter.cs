using TechTalk.SpecFlow;

namespace Samples.WinRT.Client.Tests.Steps.Adapters
{
    [Binding]
    class MainStepsAdapter
    {
        [Then(@"Application navigates to the main screen")]
        public void ThenApplicationNavigatesToTheMainScreen()
        {
            MainSteps.ThenApplicationNavigatesToTheMainScreen();
        }
    }
}
