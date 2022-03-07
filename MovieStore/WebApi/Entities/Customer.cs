using System;
using System.Collections.Generic;

namespace WebApi.Entities
{
    public class Customer:Person
    {
        public Customer()
        {
            Orders = new HashSet<Order>();
            FavoriteMovies =new HashSet<FavoriteMovie>();
        }
        public string Email { get; set; }
        public string Password { get; set; }
        public string RefreshToken { get; set; }
        public DateTime? RefreshTokenExpireDate { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<FavoriteMovie> FavoriteMovies { get; set; }
    }
}
