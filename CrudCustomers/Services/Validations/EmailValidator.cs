using CrudCustomers.Models.DTOs;
using FluentValidation;

namespace CrudCustomers.Services.Validations
{
    public class EmailValidator : AbstractValidator<EmailDto>
    {
        public EmailValidator()
        {
            RuleFor(x => x.EmailAddress)
                .NotEmpty().WithMessage("O campo Email é obrigatório")
                .EmailAddress().WithMessage("Insira um email válido");
        }
    }
}
