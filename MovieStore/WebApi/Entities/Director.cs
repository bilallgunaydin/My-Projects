using System.Collections.Generic;


namespace WebApi.Entities
{
    public class Director:Person
    {
        public Director()
        {
            Movies = new HashSet<Movie>();
        }
        public virtual ICollection<Movie> Movies { get; set; } 

    }
}