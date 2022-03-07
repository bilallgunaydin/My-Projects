using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace WebApi.Entities
{
    public class Movie
    {
        public Movie()
        {
            MovieActors = new HashSet<MovieActor>();
        }

        private readonly ILazyLoader _lazyLoader;
        public Movie(ILazyLoader lazyLoader)
        {
            _lazyLoader = lazyLoader;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string MovieName { get; set; }        
        public DateTime ReleaseDate { get; set; }
        public int Price { get; set; }
        public bool IsPassive { get; set; }=false;
        public int MovieGenreID { get; set; }
        public int DirectorID { get; set; }
        public virtual Genre MovieGenre {get; set;}
        public virtual Director Director {get; set;}
     
        public virtual ICollection<MovieActor> MovieActors {get; set;}

    }
}
