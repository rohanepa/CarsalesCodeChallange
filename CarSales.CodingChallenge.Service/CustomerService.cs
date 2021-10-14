using CarSales.CodingChallenge.Infrastructure.Dtos;
using CarSales.CodingChallenge.Infrastructure.Response;
using CarSales.CodingChallenge.Persistence.Commands;
using CarSales.CodingChallenge.Persistence.Queries;
using CarSales.CodingChallenge.Service.IoC;
using FluentValidation;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarSales.CodingChallenge.Service
{
    public class CustomerService : ServiceBase, ICustomerService
    {
        private SalesPersonSelectorFactory _salesPersonSelectorFactory;
        private IMediator _mediator;
        private AbstractValidator<CustomerDto> _customerValidator;

        public CustomerService(SalesPersonSelectorFactory salesPersonSelectorFactory, IMediator mediator, AbstractValidator<CustomerDto> customerValidator)
        {
            _salesPersonSelectorFactory = salesPersonSelectorFactory;
            _mediator = mediator;
            _customerValidator = customerValidator;
        }

        public async Task<IResponse> SaveCustomerAndAssignASalesPerson(CustomerDto customer)
        {
            //TODO: Save Customer And Assign A Sales Person
        }

        public async Task<IEnumerable<CustomerViewDto>> GetCustomers()
        {
            //TODO: Get Customers
        }
    }
}
