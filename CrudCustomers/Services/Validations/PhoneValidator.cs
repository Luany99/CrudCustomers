using CrudCustomers.Models.DTOs;
using FluentValidation;

namespace CrudCustomers.Services.Validations
{
    public class PhoneValidator : AbstractValidator<PhoneDto>
    {
        public PhoneValidator()
        {
            RuleFor(x => x.Number)
                .NotEmpty().WithMessage("O campo Telefone é obrigatório");
        }
    }
}
