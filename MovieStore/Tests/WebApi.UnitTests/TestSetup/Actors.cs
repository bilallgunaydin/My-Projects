using System.Collections.Generic;
using WebApi.DBOperations;
using WebApi.Entities;

namespace Tests.WebApi.UnitTests.TestSetup
{
    public static class Actors
    {
        public static void AddActors(this MovieStoreDbContext context){
            List<Actor> actorList= new List<Actor>()
                {
                    new Actor(){FirstName="Tim",LastName="Robbins"},
                    new Actor(){FirstName="Morgan",LastName="Freeman"},
                    new Actor(){FirstName="Marlon",LastName="Brando"},
                    new Actor(){FirstName="Al",LastName="Pacino"}
                };

            context.Actors.AddRange(actorList);
            
        }
    }
}