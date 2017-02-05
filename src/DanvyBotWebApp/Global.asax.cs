using Autofac;
using Autofac.Integration.WebApi;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Dialogs.Internals;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Web.Http;
using Microsoft.Bot.Builder.History;

namespace DanvyBotWebApp
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var builder = new ContainerBuilder();
            // register the Bot Builder module
            builder.RegisterModule(new DialogModule());
            // register the alarm dependencies
            //builder.RegisterModule(new AlarmModule());
            builder.RegisterType<DebugActivityLogger>()
                .AsImplementedInterfaces()
                .InstancePerDependency();
            builder.RegisterType<TraceActivityLogger>()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
            var config = GlobalConfiguration.Configuration;
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterWebApiFilterProvider(config);
            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
