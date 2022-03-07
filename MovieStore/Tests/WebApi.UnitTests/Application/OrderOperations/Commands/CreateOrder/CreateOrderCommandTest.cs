using System;
using System.Linq;
using AutoMapper;
using FluentAssertions;
using Tests.WebApi.UnitTests.TestSetup;
using WebApi.Application.OrderOperations.Commands.CreateOrder;
using WebApi.DBOperations;
using Xunit;

namespace Tests.WebApi.UnitTests.Application.OrderOperations.Commands.CreateOrder
{
    public class CreateOrderCommandTest : IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public CreateOrderCommandTest(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenValidInputAreGiven_Order_ShouldBeCreated()
        {

            CreateOrderCommand command = new CreateOrderCommand(_context,_mapper);
            var model = new CreateOrderModel 
            { CustomerId= 1,MovieId=1,Price=1};
            command.Model = model;

            FluentActions
                .Invoking(()=>command.Handle()).Invoke();

            var order = _context.Orders.SingleOrDefault
            (x => x.MovieId == model.MovieId 
            && x.CustomerId == model.CustomerId 
            && x.Price == model.Price);
            order.Should().NotBeNull();
        }

        [Fact]
        public void WhenValidInputAreGiven_Order_InvalidOperationException_ShouldBeReturn()
        {
            CreateOrderCommand command = new CreateOrderCommand(_context,_mapper);
            var model = new CreateOrderModel 
            { CustomerId= 100,MovieId=1,Price=1};
            command.Model = model;

            FluentActions
                .Invoking(()=> command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message
                .Should().Be("Kullanıcı bulunamadı!");
        }
    }

}