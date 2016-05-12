using Attest.Fake.Builders;
using Attest.Fake.Core;
using Attest.Fake.Registration;
using Attest.Testing.Core;
using Solid.Practices.IoC;

namespace Samples.WinRT.Client.Tests.Integration.Infra
{
    /// <summary>
    /// Base class for step-containing classes, used for [Given] steps.
    /// </summary>
    public abstract class StepsBase
    {
        /// <summary>
        /// Registers service instance into the scenario context.
        /// </summary>
        /// <typeparam name="TService">he type of service.</typeparam>
        /// <param name="instance">The instance to be registered.</param>
        protected void RegisterInstance<TService>(TService instance) where TService : class
        {
            RegistrationHelper.RegisterInstance(GetRegistrator(), instance);
        }

        /// <summary>
        /// Registers the service and its implementation types in a transient manner.
        /// </summary>
        /// <typeparam name="TService">The type of the service.</typeparam>
        /// <typeparam name="TImplementation">The type of the implementation.</typeparam>
        public static void RegisterTransient<TService, TImplementation>()
            where TImplementation : class, TService
        {
            RegistrationHelper.RegisterTransient<TService, TImplementation>(GetRegistrator());
        }

        /// <summary>
        /// Builds service from its builder and registers it into the ioc container.
        /// </summary>
        /// <typeparam name="TService">The type of service.</typeparam>
        /// <param name="builder">The builder to be registered.</param>
        protected void RegisterBuilder<TService>(FakeBuilderBase<TService> builder) where TService : class
        {
            RegistrationHelper.RegisterBuilder(GetRegistrator(), builder);
        }        

        /// <summary>
        /// Registers service fake into the scenario context.
        /// </summary>
        /// <typeparam name="TService">The type of service.</typeparam>
        /// <param name="fake">The fake to be registered.</param>
        protected void RegisterFake<TService>(IFake<TService> fake) where TService : class
        {
            RegistrationHelper.RegisterFake(GetRegistrator(), fake);
        }

        /// <summary>
        /// Registers service mock into the scenario context.
        /// </summary>
        /// <typeparam name="TService">The type of service.</typeparam>
        /// <param name="fake">The mock to be registered.</param>
        protected void RegisterMock<TService>(IMock<TService> fake) where TService : class
        {            
            RegistrationHelper.RegisterMock(GetRegistrator(), fake);
        }

        /// <summary>
        /// Resolves steps provider by type.
        /// </summary>
        /// <typeparam name="TStepsProvider">The type of steps provider.</typeparam>
        /// <returns>The steps provider.</returns>
        protected TStepsProvider GetStepsProvider<TStepsProvider>() where TStepsProvider : class, IStepsProvider
        {
            return ScenarioHelper.Get<TStepsProvider>();
        }

        private static IIocContainerRegistrator GetRegistrator()
        {
            return ScenarioHelper.Registrator;
        }
    }
}
