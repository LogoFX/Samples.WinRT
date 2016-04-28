﻿using Attest.Testing.Core;
using Samples.WinRT.Client.Tests.Contracts.ScreenObjects;
using Shouldly;

namespace Samples.WinRT.Client.Tests.Steps
{
    public static class MainSteps
    {
        private static readonly IMainScreenObject _mainScreenObject = ScenarioHelper.Get<IMainScreenObject>();

        public static void ThenApplicationNavigatesToTheMainScreen()
        {
            var isActive = _mainScreenObject.IsActive();
            isActive.ShouldBeTrue();
        }
    }
}