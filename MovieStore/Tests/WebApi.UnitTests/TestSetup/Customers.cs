using System.Collections.Generic;
using WebApi.DBOperations;
using WebApi.Entities;

namespace Tests.WebApi.UnitTests.TestSetup
{
    public static  class Customers
    {
        public static void AddCustomers(this MovieStoreDbContext context){
            List<Customer> customerList= new List<Customer>
                {
                    new Customer()
                    {
                        FirstName="John",
                        LastName="Doe",
                        Email="Johndoe@gmail.com",
                        Password="John123"
                    },

                    new Customer()
                    {
                        FirstName="Jane",
                        LastName="Doe",
                        Email="Janedoe@gmail.com",
                        Password="Jane123"
                    }
                };
            context.Customers.AddRange(customerList);
        }
    }
}