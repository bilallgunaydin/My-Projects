using System;
using System.Linq;
using AutoMapper;
using FluentAssertions;
using Tests.WebApi.UnitTests.TestSetup;
using WebApi.Application.ActorOperations.Queries.GetActorDetail;
using WebApi.DBOperations;
using Xunit;

namespace Tests.WebApi.UnitTests.Application.ActorOperations.Queries.GetActorDetail
{
    public class GetActorDetailQueryTests : IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public GetActorDetailQueryTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenNotFoundActorIdIsGiven_InvalidOperationException_ShouldBeReturn()
        {
            GetActorDetailQuery query = new GetActorDetailQuery(_context,_mapper);
            query.Id = 100;

            FluentActions.Invoking(()=>query.Handle())
                         .Should().Throw<InvalidOperationException>().And.Message
                         .Should().Be("Aktör bulunamadı!");

        }

        [Fact]
        public void WhenValidActorIdIsGiven_Actor_ShouldBeReturn()
        {
            GetActorDetailQuery query = new GetActorDetailQuery(_context,_mapper);
            query.Id = 1;

            FluentActions.Invoking(()=>query.Handle()).Invoke();

            var actor = _context.Actors.SingleOrDefault(actor => actor.Id == query.Id);
            actor.Should().NotBeNull();
        }

    }
}
