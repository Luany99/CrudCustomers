using CrudCustomers.Models.DTOs;
using FluentValidation;

namespace CrudCustomers.Services.Validations
{
    public class AddressValidator : AbstractValidator<AddressDto>
    {
        public AddressValidator()
        {
            RuleFor(x => x.Street)
                .NotEmpty().WithMessage("O campo Rua é obrigatório")
                .Length(1, 200).WithMessage("Rua deve ter no máximo 200 caracteres");

            RuleFor(x => x.Neighborhood)
                .NotEmpty().WithMessage("O campo Bairro é obrigatório")
                .Length(1, 100).WithMessage("Bairro deve ter no máximo 100 caracteres");

            RuleFor(x => x.City)
                .NotEmpty().WithMessage("O campo Cidade é obrigatório")
                .Length(1, 100).WithMessage("Cidade deve ter no máximo 100 caracteres");

            RuleFor(x => x.State)
                .NotEmpty().WithMessage("O campo Estado é obrigatório")
                .Length(2).WithMessage("Estado deve ter 2 caracteres");

            RuleFor(x => x.ZipCode)
                .NotEmpty().WithMessage("O campo CEP é obrigatório")
                .Matches(@"^\d{5}-\d{3}$")
                .WithMessage("O CEP deve ter 8 dígitos e estar no formato XXXXX-XXX");

            RuleFor(x => x.Number)
                .NotEmpty().WithMessage("O campo Número é obrigatório");
        }
    }
}
