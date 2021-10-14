using Autofac;
using CarSales.CodingChallenge.Infrastructure.Dtos;
using CarSales.CodingChallenge.Infrastructure.Enums;
using CarSales.CodingChallenge.Infrastructure.Extensions;
using CarSales.CodingChallenge.Persistence.IoC;
using CarSales.CodingChallenge.Service.Validators;
using FluentValidation;

namespace CarSales.CodingChallenge.Service.IoC
{
    public class ServiceIoCModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule<PersistenceIoCModule>();

            //Register concrete components
            builder.RegisterType<CustomerValidator>().As<AbstractValidator<CustomerDto>>();
        }
    }
}
