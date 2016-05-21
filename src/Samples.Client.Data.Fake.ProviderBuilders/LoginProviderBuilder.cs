using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Attest.Fake.LightMock;
using Attest.Fake.Setup.Contracts;
using LightMock;
using LogoFX.Client.Data.Fake.ProviderBuilders;
using Samples.Client.Data.Contracts.Providers;

namespace Samples.Client.Data.Fake.ProviderBuilders
{           
    [Serializable]
    public class LoginProviderBuilder : FakeBuilderBase<ILoginProvider>
    {
        class LoginProviderProxy : ProviderProxyBase<ILoginProvider>, ILoginProvider
        {
            public LoginProviderProxy(IInvocationContext<ILoginProvider> context)
                : base(context)
            {
            }

            public Task Login(string username, string password)
            {
                return Invoke(t => t.Login(username, password));
            }
        }

        private readonly List<Tuple<string, string>> _users = new List<Tuple<string, string>>();
        private readonly Dictionary<string, bool> _isLoginAttemptSuccessfulCollection = new Dictionary<string, bool>();
        
        private LoginProviderBuilder()
            :base(FakeFactoryHelper.CreateFake<ILoginProvider>(c => new LoginProviderProxy(c)))
        {

        }

        public static LoginProviderBuilder CreateBuilder()
        {
            return new LoginProviderBuilder();
        }

        public void WithUser(string username, string password)
        {
            _users.Add(new Tuple<string, string>(username, password));            
        }

        protected override IServiceCall<ILoginProvider> CreateServiceCall(IHaveNoMethods<ILoginProvider> serviceCallTemplate)
        {
            var setup = serviceCallTemplate
               .AddMethodCallAsync<string, string>(t => t.Login(The<string>.IsAnyValue, The<string>.IsAnyValue),
                    (r, login, password) =>
                           _isLoginAttemptSuccessfulCollection.ContainsKey(login)
                               ? _isLoginAttemptSuccessfulCollection[login]
                                   ? r.Complete()
                                   : r.Throw(new Exception("unable to login"))
                               : r.Throw(new Exception("unable to login")));
            return setup;
        }

        public void WithSuccessfulLogin(string username)
        {
            _isLoginAttemptSuccessfulCollection[username] = true;
        }
    }
}