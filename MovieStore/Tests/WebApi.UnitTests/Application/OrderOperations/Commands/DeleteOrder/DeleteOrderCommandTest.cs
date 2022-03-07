using System;
using System.Linq;
using AutoMapper;
using FluentAssertions;
using Tests.WebApi.UnitTests.TestSetup;
using WebApi.Application.OrderOperations.Commands.DeleteOrder;
using WebApi.DBOperations;
using Xunit;

namespace Tests.WebApi.UnitTests.Application.OrderOperations.Commands.DeleteOrder
{
    public class DeleteOrderCommandTest : IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public DeleteOrderCommandTest(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenNotFoundOrderIdIsGiven_InvalidOperationException_ShouldBeReturn()
        {
            DeleteOrderCommand command = new DeleteOrderCommand(_context);
            command.OrderId =100;

            FluentActions.Invoking(()=>command.Handle())
                         .Should().Throw<InvalidOperationException>().And.Message
                         .Should().Be("Sipariş bulunamadı!");

        }

        [Fact]
        public void WhenValidOrderIdIsGiven_Movie_ShouldBeDeleted()
        {

            DeleteOrderCommand command = new DeleteOrderCommand(_context);
            command.OrderId = 1;;

            FluentActions.Invoking(()=>command.Handle()).Invoke();
            var order = _context.Orders.SingleOrDefault
            (order => order.Id==command.OrderId && order.IsPassive==false);
            order.Should().BeNull();

        }
    }
}