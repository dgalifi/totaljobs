using System.Diagnostics.CodeAnalysis;
using PairingTest.Web.Mappers;
using SimpleInjector;
using System.Web.Mvc;
using PairingTest.Web.Services;
using PairingTest.Web.Services.Wrapper;
using SimpleInjector.Integration.Web.Mvc;

namespace PairingTest.Web.IoC
{
    public static class ContainerConfig
    {
        [ExcludeFromCodeCoverage]
        public static void Setup()
        {
            var container = new Container();

            container.RegisterSingleton<IMapper, Mapper>();
            container.RegisterSingleton<IQuestionnaireService, QuestionnaireService>();
            container.RegisterSingleton<IHttpClientWrapper, HttpClientWrapper>();

            container.Verify();
            
            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }
    }
}