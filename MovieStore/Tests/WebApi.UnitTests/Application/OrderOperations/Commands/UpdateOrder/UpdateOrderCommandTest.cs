using System;
using System.Linq;
using AutoMapper;
using FluentAssertions;
using Tests.WebApi.UnitTests.TestSetup;
using WebApi.Application.OrderOperations.Commands.UpdateOrder;
using WebApi.DBOperations;
using Xunit;

namespace Tests.WebApi.UnitTests.Application.OrderOperations.Commands.UpdateOrder
{
    public class UpdateOrderCommandTest : IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public UpdateOrderCommandTest(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

      [Fact]
        public void WhenNotFoundOrderIdIsGiven_InvalidOperationException_ShouldBeReturn()
        {
            UpdateOrderCommand command = new UpdateOrderCommand(_context);
            command.OrderId =100;

            FluentActions.Invoking(()=>command.Handle())
                         .Should().Throw<InvalidOperationException>().And.Message
                         .Should().Be("Sipariş bulunamadı!");
        }

        [Fact]
        public void WhenValidInputAreGiven_Movie_ShouldBeUpdated()
        {

            UpdateOrderCommand command = new UpdateOrderCommand(_context);
            command.OrderId=1;
            var model = new UpdateOrderViewModel 
            { 
            CustomerId=1, MovieId=1, Price=10};
            command.Model = model;
            FluentActions.Invoking(()=> command.Handle()).Invoke();

            var order=_context.Orders.SingleOrDefault(order=> order.Id==command.OrderId);
            order.Should().NotBeNull();
            order.CustomerId.Should().Be(model.CustomerId);
            order.MovieId.Should().Be(model.MovieId);
            order.Price.Should().Be(model.Price); 
        }
    }
}