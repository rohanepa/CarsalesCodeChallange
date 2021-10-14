using CarSales.CodingChallenge.Infrastructure.Dtos;
using CarSales.CodingChallenge.Persistence.Database;
using CarSales.CodingChallenge.Persistence.Domain;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CarSales.CodingChallenge.Persistence.Queries
{
    public class GetAvailableSalesPersonsQuery : IRequest<IEnumerable<SalesPersonWithGroupsDto>>
    {
    }

    public class GetAvailableSalesPersonsQueryHandler : IRequestHandler<GetAvailableSalesPersonsQuery, IEnumerable<SalesPersonWithGroupsDto>>
    {
        private ICodingChallengeDataStore _dataStore;

        public GetAvailableSalesPersonsQueryHandler(ICodingChallengeDataStore dataStore)
        {
            _dataStore = dataStore;
        }

        public async Task<IEnumerable<SalesPersonWithGroupsDto>> Handle(GetAvailableSalesPersonsQuery request, CancellationToken cancellationToken)
        {
            var customers = _dataStore.Collection<Customer>("customer").ToList();

            return _dataStore.Collection<SalesPerson>("salesPerson")
                .Where(x => !customers.Any(cus => cus.SalesPersonName == x.Name))
                .Select(sp => new SalesPersonWithGroupsDto
                {
                    Name = sp.Name,
                    Groups = sp.Groups
                }).ToList();
        }
    }
}
