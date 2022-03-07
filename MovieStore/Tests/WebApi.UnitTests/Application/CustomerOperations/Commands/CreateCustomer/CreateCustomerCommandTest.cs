using System;
using System.Linq;
using AutoMapper;
using FluentAssertions;
using Tests.WebApi.UnitTests.TestSetup;
using WebApi.Application.CustomerOperations.Commands.CreateCustomer;
using WebApi.DBOperations;
using WebApi.Entities;
using Xunit;

namespace Tests.WebApi.UnitTests.Application.CustomerOperations.Commands.CreateCustomer
{
    public class CreateCustomerCommandTest : IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public CreateCustomerCommandTest(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenAlreadyCustomerNameIsGiven_InvalidOperationException_ShouldBeReturn()
        {
           var customer = new Customer 
           {
             FirstName = "CustomerFirstName", 
             LastName = "CustomerLastName", 
             Email = "customer@gmail", 
             Password="customerTest" 
           };  
            _context.Customers.Add(customer);
            _context.SaveChanges();

            CreateCustomerCommand command = new CreateCustomerCommand(_context, _mapper);
            command.Model = new CreateCustomerModel 
            { 
                FirstName = customer.FirstName, 
                LastName = customer.LastName, 
                Email = customer.Email, 
                Password = customer.Password
            };

            FluentActions
                .Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>()
                .And.Message.Should().Be("Kullanıcı zaten mevcut.");
        }

        [Fact]
        public void WhenValidInputAreGiven_Customer_ShouldBeCreated()
        {
            CreateCustomerCommand command = new CreateCustomerCommand(_context, _mapper);
            command.Model = new CreateCustomerModel 
            { 
               FirstName = "CustomerFirstName", 
                LastName = "CustomerLastName", 
                Email = "customer@gmail", 
                Password="customerTest" 
            };

            FluentActions
                .Invoking(()=>command.Handle()).Invoke();

            var customer = _context.Customers
            .FirstOrDefault(customer => customer.FirstName.ToLower() == command.Model.FirstName.ToLower() 
            &&  customer.LastName.ToLower() == command.Model.LastName.ToLower());
            customer.Should().NotBeNull();
            customer.FirstName.Should().Be(command.Model.FirstName);
            customer.LastName.Should().Be(command.Model.LastName);

        }
    }

}