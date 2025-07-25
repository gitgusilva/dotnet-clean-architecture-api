using FluentValidation;
using MyApi.Application.DTOs;

namespace MyApi.Application.Validators
{
    /// <summary>
    /// Validador para atualização de produtos.
    /// </summary>
    public class UpdateProductDtoValidator : AbstractValidator<UpdateProductDto>
    {
        /// <summary>
        /// Inicializa as regras de validação para atualização de produtos.
        /// </summary>
        public UpdateProductDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("O nome é obrigatório.")
                .MaximumLength(100).WithMessage("O nome deve ter no máximo 100 caracteres.");
            RuleFor(x => x.Price)
                .GreaterThan(0).WithMessage("O preço deve ser maior que zero.");
        }
    }
} 