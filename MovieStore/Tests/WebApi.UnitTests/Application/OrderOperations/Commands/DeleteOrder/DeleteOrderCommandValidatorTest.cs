using AutoMapper;
using FluentAssertions;
using Tests.WebApi.UnitTests.TestSetup;
using WebApi.Application.OrderOperations.Commands.DeleteOrder;
using WebApi.DBOperations;
using Xunit;

namespace Tests.WebApi.UnitTests.Application.OrderOperations.Commands.DeleteOrder
{
    public class DeleteOrderCommandValidatorTest : IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public DeleteOrderCommandValidatorTest(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void WhenInvalidMovieIdIsGiven_Validator_ShouldBeReturnErrors(int orderId)
        {
            DeleteOrderCommand command = new DeleteOrderCommand(null);
            command.OrderId = orderId;
            DeleteOrderCommandValidator validator = new DeleteOrderCommandValidator();
            var result = validator.Validate(command);

            result.Errors.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public void WhenValidMovieIdIsGiven_Validator_ShouldNotReturnError()
        {
            DeleteOrderCommand command = new DeleteOrderCommand(null);
            command.OrderId = 1;
            DeleteOrderCommandValidator validator = new DeleteOrderCommandValidator();
            var result = validator.Validate(command);

            result.Errors.Count.Should().Be(0);
        }
    }
}