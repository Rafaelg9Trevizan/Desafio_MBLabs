using g9events.Models;
using FluentValidation;

namespace TicketValidator
{
    public class TicketValidator : AbstractValidator<Ticket>
    {
        public TicketValidator()
        {
            RuleFor(x => x.price)
                .NotEmpty().WithMessage("Price is Empty!")
                .GreaterThanOrEqualTo(0);

            RuleFor(x => x.type)
                .NotEmpty().WithMessage("Type is Empty!")
                .MaximumLength(100).WithMessage("Invalid Type!")
                .MinimumLength(2).WithMessage("Invalid Type!");

            RuleFor(x => x.event_id)
                .NotEmpty().WithMessage("Event Id is Empty!");
        }
    }
}