using System;
using System.Linq;
using AutoMapper;
using FluentAssertions;
using Tests.WebApi.UnitTests.TestSetup;
using WebApi.Application.DirectorOperations.Queries.GetDirectorDetail;
using WebApi.DBOperations;
using Xunit;

namespace Tests.WebApi.UnitTests.Application.DirectorOperations.Queries.GetDirectorDetail
{
    public class GetDirectorDetailQueryTests : IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public GetDirectorDetailQueryTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenNotFoundDirectorIdIsGiven_InvalidOperationException_ShouldBeReturn()
        {  
            GetDirectorDetailQuery query = new GetDirectorDetailQuery(_context,_mapper);
            query.DirectorId = 100;

            FluentActions.Invoking(()=>query.Handle()).Should()
                         .Throw<InvalidOperationException>().And.Message
                         .Should().Be("Yönetmen bulunamadı.");

        }

        [Fact]
        public void WhenValidDirectorIdIsGiven_Director_ShouldBeReturn()
        {
            GetDirectorDetailQuery query = new GetDirectorDetailQuery(_context,_mapper);
            query.DirectorId = 1;

            FluentActions.Invoking(()=>query.Handle()).Invoke();

            var actor = _context.Actors.SingleOrDefault(actor => actor.Id == query.DirectorId);
            actor.Should().NotBeNull();
        }

    }
}
