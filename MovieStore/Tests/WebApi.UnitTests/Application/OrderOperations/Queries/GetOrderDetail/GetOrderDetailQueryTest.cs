using System;
using System.Linq;
using AutoMapper;
using FluentAssertions;
using Tests.WebApi.UnitTests.TestSetup;
using WebApi.Application.OrderOperations.Queries.GetOrderDetail;
using WebApi.DBOperations;
using Xunit;

namespace Tests.WebApi.UnitTests.Application.OrderOperations.Queries.GetOrderDetail
{
    public class GetOrderDetailQueryTest : IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public GetOrderDetailQueryTest(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenNotFoundOrderIdIsGiven_InvalidOperationException_ShouldBeReturn()
        {
            GetOrderDetailQuery query = new GetOrderDetailQuery(_context,_mapper);
            query.OrderId = 100;
            FluentActions.Invoking(()=>query.Handle())
                         .Should().Throw<InvalidOperationException>().And.Message
                         .Should().Be("Sipariş bulunamadı!");
        }

        [Fact]
        public void WhenValidOrderIdIsGiven_Order_ShouldBeReturn()
        {
            GetOrderDetailQuery query = new GetOrderDetailQuery(_context,_mapper);
            query.OrderId =1;

            FluentActions.Invoking(()=>query.Handle()).Invoke();

            var movie = _context.Orders.SingleOrDefault(a => a.Id == query.OrderId);
            movie.Should().NotBeNull();            
        }

    }
}
