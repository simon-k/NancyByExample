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
            /*pipelines.OnError += (ctx, ex) =>
            {
                Console.WriteLine(string.Format("Error occured during request ('{0}')", ctx.Request.Path), ex);
                return null;
            };*/
        }

        protected override void ConfigureApplicationContainer(ILifetimeScope existingContainer)
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<UserRepository>().As<IUserRepository>().SingleInstance();
            builder.Update(existingContainer.ComponentRegistry);
        }
    }
}
