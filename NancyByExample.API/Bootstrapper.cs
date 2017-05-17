using Autofac;
using Nancy.Bootstrapper;
using Nancy.Bootstrappers.Autofac;
using NancyByExample.API.Repository;

namespace NancyByExample.API
{
    public class Bootstrapper : AutofacNancyBootstrapper
    {
        protected override void ApplicationStartup(ILifetimeScope container, IPipelines pipelines)
        {
            base.ApplicationStartup(container, pipelines);
        }

        protected override void ConfigureApplicationContainer(ILifetimeScope existingContainer)
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<UserRepository>().As<IUserRepository>().SingleInstance();
            builder.Update(existingContainer.ComponentRegistry);
        }
    }
}
