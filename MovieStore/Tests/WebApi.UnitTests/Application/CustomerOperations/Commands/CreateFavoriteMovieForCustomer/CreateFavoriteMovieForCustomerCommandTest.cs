using System;
using System.Collections.Generic;
using AutoMapper;
using FluentAssertions;
using Tests.WebApi.UnitTests.TestSetup;
using WebApi.Application.CustomerOperations.Commands.CreateCustomer;
using WebApi.DBOperations;
using WebApi.Entities;
using Xunit;

namespace Tests.WebApi.UnitTests.Application.CustomerOperations.Commands.CreateFavoriteMovieForCustomer
{
    public class CreateFavoriteMovieForCustomerCommandTest : IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public CreateFavoriteMovieForCustomerCommandTest(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenAlreadyCustomerNameIsGiven_InvalidOperationException_ShouldBeReturn()
        {
            CreateFavoriteMovie command= new CreateFavoriteMovie(_context, _mapper);
            command.CustomerId="ahmet";
            CreateFavoriteMovieModel movie = new CreateFavoriteMovieModel();
            movie.Movies=new List<int>();
            movie.Movies.Add(1);

            FluentActions
                .Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>()
                .And.Message.Should().Be("Kullanıcı bulunamadı.");
        }

        [Fact]
        public void WhenAlreadyCustomerNameIsGiven_ShouldBeCreated()
        {   var customer=new Customer
            {
                FirstName = "CustomerFirstName",
                LastName = "CustomerLastName",
                Email = "customer@gmail",
                Password = "customerTest"
            };
            _context.Customers.Add(customer);
            _context.SaveChanges();
            CreateFavoriteMovie command= new CreateFavoriteMovie(_context, _mapper);
            command.CustomerId="CustomerFirstName";
            CreateFavoriteMovieModel movie = new CreateFavoriteMovieModel();
            movie.Movies=new List<int>();
            movie.Movies.Add(1);

            FluentActions
                .Invoking(()=>command.Handle()).Invoke();  
            
        }
    }
}