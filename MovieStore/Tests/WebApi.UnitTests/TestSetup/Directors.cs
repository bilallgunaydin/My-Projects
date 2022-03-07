using System.Collections.Generic;
using WebApi.DBOperations;
using WebApi.Entities;

namespace Tests.WebApi.UnitTests.TestSetup
{
    public static class Directors
    {
        public static void AddDirectors(this MovieStoreDbContext context){
             List<Director> directorList =new List<Director>()
                {
                    new Director() {FirstName="Frank",LastName="DaraBont"},
                    new Director() {FirstName="Francis Ford",LastName="Coppola"},
                    
                };
            context.Directors.AddRange(directorList);
            
        }
    }
}