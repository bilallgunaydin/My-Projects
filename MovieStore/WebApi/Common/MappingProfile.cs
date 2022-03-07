using System.Linq;
using AutoMapper;
using WebApi.Application.ActorOperations.Commands.CreateActor;
using WebApi.Application.ActorOperations.Queries.GetActors;
using WebApi.Application.CustomerOperations.Commands.CreateCustomer;
using WebApi.Application.CustomerOperations.Queries.GetCustomerDetail;
using WebApi.Application.DirectorOperations.Commands.CreateDirector;
using WebApi.Application.DirectorOperations.Queries.GetDirectorDetail;
using WebApi.Application.DirectorOperations.Queries.GetDirectors;
using WebApi.Application.GenreOperations.Commands.CreateGenre;
using WebApi.Application.GenreOperations.Queries.GetGenreDetail;
using WebApi.Application.GenreOperations.Queries.GetGenres;
using WebApi.Application.MovieOperations.Commands.CreateMovie;
using WebApi.Application.MovieOperations.Queries.GetMovieDetail;
using WebApi.Application.MovieOperations.Queries.GetMovies;
using WebApi.Application.OrderOperations.Queries.GetOrderDetail;
using WebApi.Application.OrderOperations.Queries.GetOrders;
using WebApi.Application.OrderOperations.Commands.CreateOrder;
using WebApi.Entities;
using WebApi.Application.ActorOperations.Queries.GetActorDetail;

namespace WebApi.Common
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            //Movie
            //GetMovies
            CreateMap<Movie, MoviesViewModel>().ForMember(dest => dest.Actors, opt => opt.MapFrom(src => src.MovieActors.Select(ma => ma.Actor).ToList()))
                                               .ForMember(dest => dest.MovieGenre, opt => opt.MapFrom(src => src.MovieGenre.GenreName.ToString()))
                                               .ForMember(dest => dest.Director, opt => opt.MapFrom(src => src.Director.FullName.ToString()));
            CreateMap<Actor, MoviesViewModel.MovieActor>();

            //GetMovieDetail
            CreateMap<Movie, MovieDetailViewModel>().ForMember(dest => dest.Actors, opt => opt.MapFrom(src => src.MovieActors.Select(ma => ma.Actor).ToList()))
                                                    .ForMember(dest => dest.MovieGenre, opt => opt.MapFrom(src => src.MovieGenre.GenreName.ToString()))
                                                    .ForMember(dest => dest.Director, opt => opt.MapFrom(src => src.Director.FullName.ToString()));
            //CreateMovie
            CreateMap<Actor, MovieDetailViewModel.MovieActor>();

            CreateMap<CreateMovieModel, Movie>();
            // CreateMap<CreateMovieModel.MovieActor, MovieActor>();


            //Actor
            //GetActors
            CreateMap<Actor, ActorsViewModel>()
                .ForMember(dest => dest.Movies, opt => opt
                .MapFrom(src => src.MovieActors
                .Select(ma => ma.Movie).ToList()));
            CreateMap<Movie, ActorsViewModel.MovieActor>();

            //GetActorDetail
            CreateMap<Actor, ActorDetailViewModel>()
                .ForMember(dest => dest.Movies, opt => opt
                .MapFrom(src => src.MovieActors
                .Select(ma => ma.Movie).ToList()));
            CreateMap<Movie, ActorDetailViewModel.MovieActor>();

            //CreateActor


            CreateMap<CreateActorCommandModel, Actor>();

            CreateMap<Movie, ActorsViewModel.MovieActor>();


            //MovieActor
            CreateMap<CreateMovieActorViewModel, MovieActor>();
            
            //ActorMovie
            CreateMap<CreateActorMovieViewModel, MovieActor>();

            //Genre
            //CreateGenre
            CreateMap<CreateGenreModel,Genre>();

            //GetGenres
            CreateMap<Genre, GenresViewModel>()
                    .ForMember(dest=> dest.Movies, opt=>
                    opt.MapFrom(src=> src.Movies.ToList()));
            CreateMap<Movie, GenresViewModel.GenreMovieVM>();

            //GetGenreDetail
            CreateMap<Genre, GenreViewModel>()
                    .ForMember(dest=> dest.Movies, opt=>
                    opt.MapFrom(src=> src.Movies.ToList()));
            CreateMap<Movie, GenreViewModel.GenreMovieVM>();

            //Director
            //CreateDirector
            CreateMap<CreateDirectorModel, Director>();
            
            //GetDirectors
            CreateMap<Director, DirectorsViewModel>()
                .ForMember(dest=> dest.Movies, opt=>
                opt.MapFrom(src=> src.Movies.ToList()));
            CreateMap<Movie, DirectorsViewModel.DirectorsMovieVM>();    
            //GetDirectorDetail
            CreateMap<Director, DirectorViewModel>()
                .ForMember(dest=> dest.Movies, opt=>
                opt.MapFrom(src=> src.Movies.ToList()));
            CreateMap<Movie, DirectorViewModel.DirectorMovieVM>(); 


            //Customer
            //CreateCustomer
            CreateMap<CreateCustomerModel,Customer>();

            //GetCustomerDetail
            CreateMap<Customer, CustomerDetailViewModel>()
                    .ForMember(dest=> dest.FavoriteMovies, opt=>
                    opt.MapFrom(src=> src.FavoriteMovies.Select(cfg=> cfg.Movie).ToList()))    
                    .ForMember(dest=> dest.Orders, opt=> opt.MapFrom(src=> src.Orders.ToList()));
            CreateMap<Movie,CustomerDetailViewModel.CustomerFavoriteMovieVM>();
            CreateMap<Order,CustomerDetailViewModel.OrdersMovie>();

            //Order
            //CreateOrder
            CreateMap<CreateOrderModel, Order>();

            //GetOrderDetail
            CreateMap<Order,OrderMovieDetailViewModel>().ForMember(dest => dest.Customer , opt => opt.MapFrom(src => src.Customer.FullName))
                                                    .ForMember(dest => dest.MovieName , opt => opt.MapFrom(src => src.Movie.MovieName));
            ////GetOrders
            CreateMap<Order,OrdersViewModel>().ForMember(dest => dest.MovieName , opt => opt.MapFrom(src => src.Movie.MovieName));
                                            
        }
    }
}