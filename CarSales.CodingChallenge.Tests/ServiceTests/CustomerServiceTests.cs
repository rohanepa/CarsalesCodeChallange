using CarSales.CodingChallenge.Infrastructure.Dtos;
using CarSales.CodingChallenge.Infrastructure.Enums;
using CarSales.CodingChallenge.Persistence.Commands;
using CarSales.CodingChallenge.Persistence.Queries;
using CarSales.CodingChallenge.Service;
using CarSales.CodingChallenge.Service.IoC;
using CarSales.CodingChallenge.Service.RuleEngine;
using CarSales.CodingChallenge.Service.Validators;
using MediatR;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarSales.CodingChallenge.Tests.ServiceTests
{
    [TestClass]
    public class CustomerServiceTests
    {
        private ICustomerService _customerService;
        private IMediator _mediator;
        private List<SalesPersonWithGroupsDto> _salesPersons = new List<SalesPersonWithGroupsDto>();
        private SalesPersonSelectorFactory _salesPersonSelectorFactory;

        public CustomerServiceTests()
        {
            SetupTestData();
            _mediator = Substitute.For<IMediator>();
            _salesPersonSelectorFactory = Substitute.For<SalesPersonSelectorFactory>();

            var customerValidator = new CustomerValidator();

            _customerService = new CustomerService(_salesPersonSelectorFactory, _mediator, customerValidator);
        }

        [TestMethod]
        public async Task GivenSaveAndAssignSalesPersonIsCalled_WhenAllTheDetailsAreProvided_ThenShouldReturnTheCustomerWithAssignedSalesPerson()
        {
            //Arrange
            var customer = new CustomerDto
            {
                Name = "Customer 1",
                SpeakingLanguage = SpeakingLanguage.Greek,
                VehicleType = VehicleType.SportsCar
            };
            _mediator.Send(Arg.Any<GetAvailableSalesPersonsQuery>()).Returns(_salesPersons);
            _mediator.Send(Arg.Any<AddCustomerCommand>()).ReturnsForAnyArgs(Task.FromResult<Unit>(new Unit()));
            _mediator.Send(Arg.Any<GetCustomersQuery>()).Returns(new List<CustomerViewDto>
            {
                new CustomerViewDto
                {
                    Id = "1",
                    Name = "Cierra Vega",
                    SalesPersonName = "Sales Person 1",
                    SpeakingLanguage = SpeakingLanguage.Greek,
                    VehicleType = VehicleType.SportsCar
                }
            });

            var salesPerson = Substitute.For<ISalesPerson>();
            _salesPersonSelectorFactory(Arg.Any<VehicleType>(), Arg.Any<SpeakingLanguage>()).Returns(salesPerson);
            salesPerson.SelectSalesPersons(Arg.Any<List<SalesPersonWithGroupsDto>>()).Returns(new List<SalesPersonWithGroupsDto>
            {
                new SalesPersonWithGroupsDto
                {
                    Name = "Cierra Vega",
                    Groups = new[] {"A"}
                },
                new SalesPersonWithGroupsDto
                {
                    Name = "Alden Cantrell",
                    Groups = new[] {"B", "D"}
                }
            });

            //Act
            var response = await _customerService.SaveCustomerAndAssignASalesPerson(customer);

            //Assert
            Assert.IsNotNull(response);
            Assert.IsTrue(response.Success);
            var result = response.Result<List<CustomerViewDto>>();
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count);
        }

        [TestMethod]
        public async Task GivenSaveAndAssignSalesPersonIsCalled_WhenAllTheDetailsAreProvidedAndNoSalesPers_ThenShouldReturnErrorResponse()
        {
            //Arrange
            var customer = new CustomerDto
            {
                Name = "Customer 1",
                SpeakingLanguage = SpeakingLanguage.Greek,
                VehicleType = VehicleType.SportsCar
            };
            _mediator.Send(Arg.Any<GetAvailableSalesPersonsQuery>()).Returns(_salesPersons);
            _mediator.Send(Arg.Any<AddCustomerCommand>()).ReturnsForAnyArgs(Task.FromResult<Unit>(new Unit()));
            _mediator.Send(Arg.Any<GetCustomersQuery>()).Returns(new List<CustomerViewDto>
            {
                new CustomerViewDto
                {
                    Id = "1",
                    Name = "Cierra Vega",
                    SalesPersonName = "Sales Person 1",
                    SpeakingLanguage = SpeakingLanguage.Greek,
                    VehicleType = VehicleType.SportsCar
                }
            });

            var salesPerson = Substitute.For<ISalesPerson>();
            _salesPersonSelectorFactory(Arg.Any<VehicleType>(), Arg.Any<SpeakingLanguage>()).Returns(salesPerson);
            salesPerson.SelectSalesPersons(Arg.Any<List<SalesPersonWithGroupsDto>>()).Returns(new List<SalesPersonWithGroupsDto>());

            //Act
            var response = await _customerService.SaveCustomerAndAssignASalesPerson(customer);

            //Assert
            Assert.IsNotNull(response);
            Assert.IsFalse(response.Success);
            Assert.AreEqual("All salespeople are busy.", response.ValidationResults.First().ErrorMessage);
        }

        private void SetupTestData()
        {
            _salesPersons = new List<SalesPersonWithGroupsDto>
            {
                new SalesPersonWithGroupsDto
                {
                    Name = "Cierra Vega",
                    Groups = new[] {"A"}
                },
                new SalesPersonWithGroupsDto
                {
                    Name = "Alden Cantrell",
                    Groups = new[] {"B", "D"}
                },
                new SalesPersonWithGroupsDto
                {
                    Name = "Kierra Gentry",
                    Groups = new[] { "A", "C" }
                },
                new SalesPersonWithGroupsDto
                {
                    Name = "Pierre Cox",
                    Groups = new[] { "D" }
                },
                new SalesPersonWithGroupsDto
                {
                    Name = "Thomas Crane",
                    Groups = new[] { "A", "B" }
                },
                new SalesPersonWithGroupsDto
                {
                    Name = "Miranda Shaffer",
                    Groups = new[] {"B"}
                },
                new SalesPersonWithGroupsDto
                {
                    Name = "Bradyn Kramer",
                    Groups = new[] {"D"}
                },
                new SalesPersonWithGroupsDto
                {
                    Name = "Alvaro Mcgee",
                    Groups = new[] { "A", "D", "C" }
                }
            };
        }
    }
}
