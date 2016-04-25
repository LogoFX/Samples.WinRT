﻿using TechTalk.SpecFlow;

namespace Samples.WinRT.Client.Tests.Steps.Adapters
{
    [Binding]
    public sealed class LoginStepsAdapter
    {
        [When(@"I set the username to ""(.*)""")]
        public void WhenISetTheUsernameTo(string username)
        {
            LoginSteps.WhenISetTheUsernameTo(username);
        }

        [When(@"I log in to the system")]
        public void WhenILogInToTheSystem()
        {
            LoginSteps.WhenILogInToTheSystem();
        }

        [Then(@"the login screen is displayed")]
        public void ThenTheLoginScreenIsDisplayed()
        {
            LoginSteps.ThenTheLoginScreenIsDisplayed();
        }        
    }
}
