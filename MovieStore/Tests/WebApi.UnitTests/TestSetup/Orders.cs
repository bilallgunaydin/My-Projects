using System;
using System.Collections.Generic;
using WebApi.DBOperations;
using WebApi.Entities;

namespace Tests.WebApi.UnitTests.TestSetup
{
    public static class Orders
    {
        public static void AddOrders(this MovieStoreDbContext context){
            List<Order> orderList= new List<Order>
                {
                    new Order()
                    {
                        MovieId=1,
                        BuyingDate=new DateTime(2020,01,01),
                        CustomerId=1,
                        Price=10
                    },

                    new Order()
                    {
                        MovieId=2,
                        BuyingDate=new DateTime(2020,01,02),
                        CustomerId=2,
                        Price=15
                    }
                };
            context.Orders.AddRange(orderList);
        }
    }
}