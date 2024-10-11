using CrudCustomers.Models.DTOs;
using FluentValidation;

namespace CrudCustomers.Services.Validations
{
    public class CustomerValidator : AbstractValidator<CustomerDto>
    {
        public CustomerValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("O campo nome é obrigatório")
                .Length(1, 100).WithMessage("O nome deve ter no máximo 100 caracteres");

            RuleFor(x => x.CNPJ)
                .NotEmpty().WithMessage("O campo CNPJ é obrigatório")
                .Length(14).WithMessage("CNPJ deve ter 14 digitos");

            RuleForEach(x => x.Addresses)
                .SetValidator(new AddressValidator());

            RuleForEach(x => x.Phones)
                .SetValidator(new PhoneValidator());

            RuleForEach(x => x.Emails)
                .SetValidator(new EmailValidator());
        }
    }
}
