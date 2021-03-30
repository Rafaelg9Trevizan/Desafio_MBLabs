using g9events.Models;
using FluentValidation;

namespace ClientValidator
{
    public class ClientValidator : AbstractValidator<Client>
    {
        public ClientValidator()
        {
            RuleFor(x => x.name)
                .NotEmpty().WithMessage("Name is Empty!")
                .MaximumLength(100).WithMessage("Invalid Name!")
                .MinimumLength(6).WithMessage("Invalid Name!");

            RuleFor(x => x.cpf)
                .NotEmpty().WithMessage("CPF is Empty!")
                .MaximumLength(11).WithMessage("Invalid CPF!")
                .MinimumLength(11).WithMessage("Invalid CPF!");

            RuleFor(x => x.categories)
                .NotEmpty().WithMessage("Categorie is Empty")
                .IsInEnum().WithMessage("Invalid Categorie!");

            RuleFor(x => x.cellphone)
                .NotEmpty().WithMessage("Cellphone is Empty!")
                .MaximumLength(11).WithMessage("Invalid is Cellphone!")
                .MinimumLength(11).WithMessage("Invalid is Cellphone!");
        }
     }
}
