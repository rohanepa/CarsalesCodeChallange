using CarSales.CodingChallenge.Infrastructure.Dtos;
using CarSales.CodingChallenge.Infrastructure.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarSales.CodingChallenge.Service
{
    public interface ICustomerService
    {
        Task<IResponse> SaveCustomerAndAssignASalesPerson(CustomerDto customer);
        Task<IEnumerable<CustomerViewDto>> GetCustomers();
    }
}
