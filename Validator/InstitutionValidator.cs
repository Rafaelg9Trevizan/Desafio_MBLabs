using g9events.Models;
using FluentValidation;

namespace InstitutionValidator
{
    public class InstitutionValidator : AbstractValidator<Institution>
    {
        public InstitutionValidator()
        {
            RuleFor(x => x.name)
                .NotEmpty().WithMessage("Name is Empty!")
                .MaximumLength(100).WithMessage("Invalid Name!")
                .MinimumLength(3).WithMessage("Invalid Name!");

            RuleFor(x => x.cnpj)
                .NotEmpty().WithMessage("CNPJ is Empty!")
                .MaximumLength(14).WithMessage("Invalid CNPJ!")
                .MinimumLength(14).WithMessage("Invalid CNPJ!");

            RuleFor(x => x.tipo)
                .NotEmpty().WithMessage("Type is Empty")
                .IsInEnum().WithMessage("Invalid Type!");
        }
    }
}