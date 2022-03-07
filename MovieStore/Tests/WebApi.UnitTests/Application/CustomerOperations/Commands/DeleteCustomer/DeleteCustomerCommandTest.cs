using System;
using System.Linq;
using AutoMapper;
using FluentAssertions;
using Tests.WebApi.UnitTests.TestSetup;
using WebApi.Application.CustomerOperations.Commands.DeleteCustomer;
using WebApi.DBOperations;
using WebApi.Entities;
using Xunit;

namespace Tests.WebApi.UnitTests.Application.CustomerOperations.Commands.DeleteCustomer
{
    public class DeleteCustomerCommandTest : IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public DeleteCustomerCommandTest(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenNotFoundCustomerIdIsGiven_InvalidOperationException_ShouldBeReturn()
        {
            DeleteCustomerCommand command = new DeleteCustomerCommand(_context);
            command.CustomerId = 10;

            FluentActions.Invoking(()=>command.Handle())
                         .Should().Throw<InvalidOperationException>().And.Message
                         .Should().Be("Kullanıcı bulunamadı.");

        }

        public void WhenNotExistCustomer_InvalidOperationException_ShouldBeReturn()
        {
            var customer= new Customer 
            { 
                FirstName = "Ahmet", 
                LastName = "Mehmet", 
                Email="ahmet@gmail.com",
                Password="1234567"
            };

            DeleteCustomerCommand command=new DeleteCustomerCommand(_context);
            command.CustomerId=customer.Id;
            FluentActions
                .Invoking(()=> command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message
                .Should().Be("Önce müşteriye ait siparişler silinmeli.");
        }

        [Fact]
        public void WhenValidCustomerIdIsGiven_Director_ShouldBeDeleted()
        {
            var customer = _context.Customers.SingleOrDefault(
                customer => customer.Id==1);

            DeleteCustomerCommand command=new DeleteCustomerCommand(_context);
            command.CustomerId=customer.Id;

            FluentActions.Invoking(()=>command.Handle()).Invoke();  
            var deletedCustomer = _context.Customers.
            SingleOrDefault(deletedCustomer=> deletedCustomer.Id==command.CustomerId 
            && deletedCustomer.IsPassive==false);
            deletedCustomer.Should().BeNull();

        }

    }
}
