using g9events.Models;
using FluentValidation;

namespace EventValidator
{
    public class EventValidator : AbstractValidator<Event>
    {
        public EventValidator()
        {
            RuleFor(x => x.event_name)
                .NotEmpty().WithMessage("Name is Empty!")
                .MaximumLength(100).WithMessage("Invalid Name!")
                .MinimumLength(6).WithMessage("Invalid Name!");

            RuleFor(x => x.local)
                .NotEmpty().WithMessage("Local is Empty!")
                .MaximumLength(100).WithMessage("Invalid Local!")
                .MinimumLength(6).WithMessage("Invalid Local!");

            RuleFor(x => x.description)
                .NotEmpty().WithMessage("Description is Empty!")
                .MaximumLength(255).WithMessage("Invalid Description!")
                .MinimumLength(6).WithMessage("Invalid Description!");

            RuleFor(x => x.categories)
                .NotEmpty().WithMessage("Categorie is Empty")
                .IsInEnum().WithMessage("Invalid Categorie!");

            RuleFor(x => x.event_date)
                .NotEmpty().WithMessage("Event Date is Empty!");
        }
    }
}