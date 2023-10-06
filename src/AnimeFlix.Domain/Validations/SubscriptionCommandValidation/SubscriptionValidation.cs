using AnimeFlix.Domain.Commands.SubscriptionCommand;
using AnimeFlix.Domain.Models.Plan;
using AnimeFlix.Domain.Models.User;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeFlix.Domain.Validations.SubscriptionCommandValidation
{
    public class SubscriptionValidation<T> : AbstractValidator<T> where T : SubscriptionCommand
    {
        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .GreaterThan(0).WithMessage("Invalid Id");
        }

        protected void ValidateUserId()
        {
            RuleFor(c => c.UserId)
                 .GreaterThan(0).WithMessage("Invalid UserId");
        }

        protected void ValidatePlanId()
        {
            RuleFor(c => c.PlanId)
                 .GreaterThan(0).WithMessage("Invalid UserId");
        }

    }
}
