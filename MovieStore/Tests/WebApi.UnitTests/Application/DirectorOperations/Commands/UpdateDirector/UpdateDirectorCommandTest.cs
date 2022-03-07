using System;
using System.Linq;
using FluentAssertions;
using Tests.WebApi.UnitTests.TestSetup;
using WebApi.Application.DirectorOperations.Commands.UpdateDirector;
using WebApi.DBOperations;
using Xunit;

namespace Tests.WebApi.UnitTests.Application.DirectorOperations.Commands.UpdateDirector
{
    public class UpdateDirectorCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;

        public UpdateDirectorCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
        }

        [Fact]
        public void WhenAlreadyDirectorNameIsGiven_InvalidOperationException_ShouldBeReturn()
        {
            UpdateDirectorCommand command = new UpdateDirectorCommand(_context);
            command.DirectorID=9;

            FluentActions
                .Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>()
                .And.Message.Should().Be("Yönetmen bulunamadı.");
        }

        [Fact]
        public void WhenValidInputAreGiven_Director_ShouldBeUpdated()
        {
           

            UpdateDirectorCommand command = new UpdateDirectorCommand(_context);
            var director = _context.Directors.SingleOrDefault(director=> director.Id==1);
            UpdateDirectorViewModel model = new UpdateDirectorViewModel 
            { FirstName="UpdateDirectorDirectorFirstNameTest",LastName="UpdateDirectorLastNameTest"};
            command.DirectorID = director.Id;
            command.Model = model;
           
            FluentActions
                .Invoking(()=>command.Handle()).Invoke();

            
            director.Should().NotBeNull();
            director.FirstName.Should().Be(model.FirstName);
            director.LastName.Should().Be(model.LastName);

        }
    }

}