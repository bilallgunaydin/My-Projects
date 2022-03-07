using FluentValidation;

namespace WebApi.Application.OrderOperations.Queries.GetOrders
{
    public class GetOrdersQueryValidator : AbstractValidator<GetOrdersQuery>
    {
        public GetOrdersQueryValidator()
        {
            RuleFor(query => query.CustomerId).GreaterThan(0);
            
        }
    }
}