using System;
using Attest.Testing.Core;
using Samples.WinRT.Client.ScreenObjects.Contracts;
using Shouldly;

namespace Samples.WinRT.Client.Tests.Steps
{
    public static class LoginSteps
    {
        private static readonly ILoginScreenObject _loginScreenObject = ScenarioHelper.Get<ILoginScreenObject>();

        public static void ThenTheLoginScreenIsDisplayed()
        {
            var isActive = _loginScreenObject.IsActive();
            isActive.ShouldBeTrue();
        }

        public static void WhenISetTheUsernameTo(string username)
        {
            throw new NotImplementedException();
        }

        public static void WhenILogInToTheSystem()
        {
            throw new NotImplementedException();
        }
    }
}
