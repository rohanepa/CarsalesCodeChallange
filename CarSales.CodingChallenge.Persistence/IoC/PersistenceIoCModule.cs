using Autofac;
using CarSales.CodingChallenge.Persistence.Database;
using MediatR;

namespace CarSales.CodingChallenge.Persistence.IoC
{
    public class PersistenceIoCModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
              .RegisterType<Mediator>()
              .As<IMediator>()
              .InstancePerLifetimeScope();

            builder.Register<ServiceFactory>(context =>
            {
                var c = context.Resolve<IComponentContext>();
                return t => c.Resolve(t);
            });

            builder.RegisterAssemblyTypes(ThisAssembly).AsImplementedInterfaces();
            builder.RegisterType<CodingChallengeDataStore>().As<ICodingChallengeDataStore>().InstancePerLifetimeScope();
        }
    }
}
