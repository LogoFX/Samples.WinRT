using Attest.Fake.Core;
using Attest.Fake.LightMock;
using JetBrains.Annotations;
using Solid.Practices.Modularity;

namespace Samples.Client.Data.Fake.ProviderBuilders
{
    [UsedImplicitly]
    class Module : IPlainCompositionModule
    {
        public void RegisterModule()
        {
            ConstraintFactoryContext.Current = new ConstraintFactory();
        }
    }
}
