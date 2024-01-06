using Cmms.Entities;
using FluentValidation;
using FluentValidation.AspNetCore;
using System.Linq;

namespace Cmms.Models.Validators
{
    public class CmmsQueryValidator : AbstractValidator<RestaurantQuery>
    {
        private int[] allowedPageSize = new[] { 5, 10, 15 };
        private string[] allowedSortByColumnNames = { nameof(Restaurant.Name), nameof(Restaurant.Description), nameof(Restaurant.Category) };
        public CmmsQueryValidator() 
        {
            RuleFor(r => r.PageNumber).GreaterThanOrEqualTo(1);
            RuleFor(r => r.PageSize).Custom((value, context) =>
            {
                if (!allowedPageSize.Contains(value)) {
                    context.AddFailure("PageSize",$"PageSize must in [{string.Join(",",allowedPageSize)}]");
                }
            });
            RuleFor(r => r.SortBy).Must(value => string.IsNullOrEmpty(value) || allowedSortByColumnNames.Contains(value))
                .WithMessage($"Sort by is optional, or must by in [{string.Join(",",allowedSortByColumnNames)}]");
        }
    }
}
