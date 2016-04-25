using TechTalk.SpecFlow;

namespace Samples.WinRT.Client.Tests.Steps.Adapters
{
    [Binding]
    class GeneralStepsAdapter
    {
        [When(@"I open the application")]
        public void WhenIOpenTheApplication()
        {
            GeneralSteps.WhenIOpenTheApplication();
        }
    }
}