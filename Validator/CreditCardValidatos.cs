using g9events.Models;
using FluentValidation;

namespace CreditCardValidator
{
    public class CreditCardValidator : AbstractValidator<CreditCard>
    {
        public CreditCardValidator()
        {
            RuleFor(x => x.client_id)
                .NotEmpty().WithMessage("Error! No Client for Credit Card!");

            RuleFor(x => x.owner_cpf)
                .NotEmpty().WithMessage("CPF is Empty!")
                .MaximumLength(11).WithMessage("Invalid CPF!")
                .MinimumLength(11).WithMessage("Invalid CPF!");

            RuleFor(x => x.owner_name)
                .NotEmpty().WithMessage("Name is Empty!")
                .MaximumLength(100).WithMessage("Invalid Name!")
                .MinimumLength(6).WithMessage("Invalid Name!");

            RuleFor(x => x.card_number)
                .NotEmpty().WithMessage("Card Number is Empty!")
                .CreditCard().WithMessage("Error in the Card Number! Card Number is invalid!");

            RuleFor(x => x.cvv)
                .NotEmpty().WithMessage("CVV is Empty!")
                .MaximumLength(4).WithMessage("Invalid CVV!")
                .MinimumLength(3).WithMessage("Invalid CVV!");

            RuleFor(x => x.card_validity)
                .NotEmpty().WithMessage("Validity of Card is Empty!");
        }
    }
}