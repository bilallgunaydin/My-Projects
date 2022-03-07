using System.Collections.Generic;

namespace WebApi.Entities
{
    public class Actor:Person
    {
        public Actor()
        {
            MovieActors = new HashSet<MovieActor>();
        }
        public virtual ICollection<MovieActor> MovieActors {get; set;}
    }

}