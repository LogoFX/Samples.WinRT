using Attest.Testing.Core;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using Solid.Bootstrapping;
using Solid.Practices.IoC;

namespace Samples.WinRT.Client.Tests.Integration.Infra
{
    /// <summary>
    /// Base class for all integration-tests fixtures that involve ioc container adapter 
    /// and test bootstrapper and use MSTest as test framework provider.
    /// </summary>
    /// <typeparam name="TRootObject">The type of root object, from which the test's flow starts.</typeparam>
    /// <typeparam name="TBootstrapper">The type of bootstrapper.</typeparam>
    public abstract class IntegrationTestsBase<TRootObject, TBootstrapper> : 
        IntegrationTestsBase<TRootObject>, IRootObjectFactory
        where TRootObject : class 
        where TBootstrapper : IInitializable, IHaveContainerRegistrator, IHaveContainerResolver, new()
    {
        private readonly IInitializationParametersManager<IocContainerProxy> _initializationParametersManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="IntegrationTestsBase{TRootObject,TBootstrapper}"/> class.
        /// </summary>
        /// <param name="resolutionStyle">The resolution style.</param>
        protected IntegrationTestsBase(
            InitializationParametersResolutionStyle resolutionStyle = InitializationParametersResolutionStyle.PerRequest)
        {            
            _initializationParametersManager =
                ContainerAdapterInitializationParametersManagerStore<TBootstrapper>.GetInitializationParametersManager(
                    resolutionStyle);
            ScenarioContext.Current = new Scenario();
        }

        /// <summary>
        /// Override this method to implement custom test setup logic.
        /// </summary>        
        protected override void Setup()
        {
            SetupCore();
            SetupOverride();
        }
    
        [TestInitialize]
        public void TestInitializeAdapter()
        {
            Setup();
        }

        /// <summary>
        /// Override this method to implement custom test teardown logic.
        /// </summary>        
        protected override void TearDown()
        {
            OnBeforeTeardown();
            TearDownCore();                
            OnAfterTeardown();        
        }

        [TestCleanup]
        public void TestCleanupAdapter()
        {
            TearDown();
        }

        protected void SetupCore()
        {
            var initializationParameters = _initializationParametersManager.GetInitializationParameters();
            Registrator = initializationParameters.IocContainer;
            Resolver = initializationParameters.IocContainer;
            ScenarioHelper.Initialize(initializationParameters.IocContainer, this);
        }

        /// <summary>
        /// Provides additional opportunity to modify the test setup logic.
        /// </summary>
        protected virtual void SetupOverride()
        {
            
        }

        protected void TearDownCore()
        {
            ScenarioHelper.Clear();           
        }

        /// <summary>
        /// Override to inject custom logic before the teardown starts.
        /// </summary>
        protected virtual void OnBeforeTeardown()
        {

        }

        /// <summary>
        /// Override to inject custom logic after the teardown finishes.
        /// </summary>
        protected virtual void OnAfterTeardown()
        {

        }

        private TRootObject CreateRootObjectTyped()
        {
            return CreateRootObject();
        }

        object IRootObjectFactory.CreateRootObject()
        {
            return CreateRootObjectTyped();
        }
    }

    /// <summary>
    /// Base class for all integration-tests fixtures that involve ioc container, its adapter, and test bootstrapper
    /// and use MSTest as test framework provider.
    /// </summary>
    /// <typeparam name="TContainer">The type of ioc container.</typeparam>
    /// <typeparam name="TContainerAdapter">The type of ioc container adapter.</typeparam>
    /// <typeparam name="TRootObject">The type of root object, from which the test's flow starts.</typeparam>
    /// <typeparam name="TBootstrapper">The type of bootstrapper.</typeparam>
    public abstract class IntegrationTestsBase<TContainer, TContainerAdapter, TRootObject, TBootstrapper> : 
        IntegrationTestsBase<TRootObject>,
        IRootObjectFactory        
        where TContainerAdapter : class, IIocContainer, IIocContainerAdapter<TContainer>
        where TRootObject : class 
        where TBootstrapper : IInitializable, IHaveContainer<TContainer>, new()
    {
        private readonly IInitializationParametersManager<TContainer> _initializationParametersManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="IntegrationTestsBase{TRootObject,TBootstrapper}"/> class.
        /// </summary>
        /// <param name="resolutionStyle">The resolution style.</param>
        protected IntegrationTestsBase(
            InitializationParametersResolutionStyle resolutionStyle = InitializationParametersResolutionStyle.PerRequest)
        {            
            _initializationParametersManager =
                ContainerInitializationParametersManagerStore<TBootstrapper, TContainer>.GetInitializationParametersManager(
                    resolutionStyle);
            ScenarioContext.Current = new Scenario();
        }

        /// <summary>
        /// Override this method to implement custom test setup logic.
        /// </summary>        
        protected override void Setup()
        {
            SetupCore();
            SetupOverride();
        }

        [TestInitialize]
        public void TestInitializeAdapter()
        {
            Setup();
        }

        /// <summary>
        /// Override this method to implement custom test teardown logic.
        /// </summary>        
        protected override void TearDown()
        {
            OnBeforeTeardown();
            TearDownCore();
            OnAfterTeardown();
        }

        [TestCleanup]
        public void TestCleanupAdapter()
        {
            TearDown();
        }

        private void SetupCore()
        {
            var initializationParameters = _initializationParametersManager.GetInitializationParameters();
            var containerAdapter = CreateAdapter(initializationParameters.IocContainer);
            Registrator = containerAdapter;
            Resolver = containerAdapter;
            ScenarioHelper.Initialize(containerAdapter, this);
        }

        /// <summary>
        /// Provides additional opportunity to modify the test setup logic.
        /// </summary>
        protected virtual void SetupOverride()
        {

        }        

        /// <summary>
        /// Override to provide ioc container adapter creation logic.
        /// </summary>
        /// <param name="container">The ioc container.</param>
        /// <returns></returns>
        protected abstract TContainerAdapter CreateAdapter(TContainer container);        

        private void TearDownCore()
        {
            ScenarioHelper.Clear();            
        }

        /// <summary>
        /// Override to inject custom logic before the teardown starts.
        /// </summary>
        protected virtual void OnBeforeTeardown()
        {

        }

        /// <summary>
        /// Override to inject custom logic after the teardown finishes.
        /// </summary>
        protected virtual void OnAfterTeardown()
        {

        }

        private TRootObject CreateRootObjectTyped()
        {
            return CreateRootObject();
        }

        object IRootObjectFactory.CreateRootObject()
        {
            return CreateRootObjectTyped();
        }
    }
}
