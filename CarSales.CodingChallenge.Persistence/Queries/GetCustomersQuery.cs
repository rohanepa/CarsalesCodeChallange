using CarSales.CodingChallenge.Infrastructure.Dtos;
using CarSales.CodingChallenge.Infrastructure.Enums;
using CarSales.CodingChallenge.Infrastructure.Extensions;
using CarSales.CodingChallenge.Persistence.Database;
using CarSales.CodingChallenge.Persistence.Domain;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CarSales.CodingChallenge.Persistence.Queries
{
    public class GetCustomersQuery : IRequest<IEnumerable<CustomerViewDto>>
    {
    }

    public class GetCustomerQueryHandler : IRequestHandler<GetCustomersQuery, IEnumerable<CustomerViewDto>>
    {
        private ICodingChallengeDataStore _dataStore;

        public GetCustomerQueryHandler(ICodingChallengeDataStore dataStore)
        {
            _dataStore = dataStore;
        }

        public async Task<IEnumerable<CustomerViewDto>> Handle(GetCustomersQuery request, CancellationToken cancellationToken)
        {
            return _dataStore.Collection<Customer>("customer")
                .Select(cus => new CustomerViewDto
                {
                    Id = cus.Id,
                    Name = cus.Name,
                    SalesPersonName = cus.SalesPersonName,
                    SpeakingLanguage = EnumHelper.GetValueFromDescription<SpeakingLanguage>(cus.Language),
                    VehicleType = EnumHelper.GetValueFromDescription<VehicleType>(cus.LookingFor)
                })
                .ToList();
        }
    }
}
