using CarSales.CodingChallenge.Infrastructure.Dtos;
using CarSales.CodingChallenge.Infrastructure.Extensions;
using CarSales.CodingChallenge.Persistence.Database;
using CarSales.CodingChallenge.Persistence.Domain;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CarSales.CodingChallenge.Persistence.Commands
{
    public class AddCustomerCommand : IRequest
    {
        public CustomerDto Customer { get; }
        public string SalesPersonName { get; }

        public AddCustomerCommand(CustomerDto customer, string salesPersonName)
        {
            Customer = customer;
            SalesPersonName = salesPersonName;
        }
    }

    public class AddCustomerCommandHandler : AsyncRequestHandler<AddCustomerCommand>
    {
        private ICodingChallengeDataStore _dataStore;

        public AddCustomerCommandHandler(ICodingChallengeDataStore dataStore)
        {
            _dataStore = dataStore;
        }

        protected override async Task Handle(AddCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = new Customer
            {
                Id = Guid.NewGuid().ToString(),
                Language = request.Customer.SpeakingLanguage.GetDescription(),
                LookingFor = request.Customer.VehicleType.GetDescription(),
                Name = request.Customer.Name,
                SalesPersonName = request.SalesPersonName
            };

            await _dataStore.InsertOneAsync<Customer>("customer", customer);
        }
    }
}
