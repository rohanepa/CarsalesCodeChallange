using CarSales.CodingChallenge.Infrastructure.Dtos;
using CarSales.CodingChallenge.Service;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarSales.CodingChallenge.Api.Controllers
{
    [Route("api/customers")]
    public class CustomerController : BaseController
    {
        private ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpPost()]
        public async Task<IActionResult> Post(CustomerDto customer)
        {
            return ActionResult<IEnumerable<CustomerViewDto>>(await _customerService.SaveCustomerAndAssignASalesPerson(customer));
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return ActionResult(await _customerService.GetCustomers());
        }
    }
}
