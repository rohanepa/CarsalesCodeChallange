using Autofac;
using CarSales.CodingChallenge.Service.IoC;

namespace CarSales.CodingChallenge.Api.Config
{
    public class IoCModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule<ServiceIoCModule>();
        }
    }
}
