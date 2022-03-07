
using Microsoft.EntityFrameworkCore;

namespace WebApi.Entities
{
    [Keyless]
    public class MovieActor
    {
        public int MovieID { get; set; }
        public int ActorID { get; set; }
        public Movie Movie { get; set; }
        public Actor Actor { get; set; }
    }
}