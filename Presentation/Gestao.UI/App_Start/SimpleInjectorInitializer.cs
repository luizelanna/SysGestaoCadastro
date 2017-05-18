using System.Reflection;
using System.Web;
using System.Web.Mvc;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;
using Gestao.Infra.CrossCutting.IoC;
using Microsoft.Owin;
using SimpleInjector.Advanced;

[assembly: WebActivator.PostApplicationStartMethod(typeof(Gestao.UI.App_Start.SimpleInjectorInitializer), "Initialize")]

namespace Gestao.UI.App_Start
{
    public static class SimpleInjectorInitializer
    {
        public static void Initialize()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

            // Chamada dos m�dulos do Simple Injector
            InitializeContainer(container);

            // Necess�rio para registrar o ambiente do Owin que � depend�ncia do Identity
            // Feito fora da camada de IoC para n�o levar o System.Web para fora
            container.RegisterPerWebRequest(() =>
            {
                if (HttpContext.Current != null && HttpContext.Current.Items["owin.Environment"] == null && container.IsVerifying())
                {
                    return new OwinContext().Authentication;
                }
                return HttpContext.Current.GetOwinContext().Authentication;

            });

            //container.Register<HttpContextBase>(() =>
            //{
            //    var context = HttpContext.Current;
            //    if (context == null && container.IsVerifying)
            //        return new FakeHttpContext();
            //    return new HttpContextWrapper(context);
            //},Lifestyle.Scoped);

            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());

            container.Verify();

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }

        public class FakeHttpContext : HttpContextBase { }

        private static void InitializeContainer(Container container)
        {
            BootStrapper.RegisterServices(container);
        }
    }
}