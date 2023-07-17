using FluentValidation;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace ShopApp.Api.Dtos.BrandDtos
{
    public class BrandEditDto
    {
        public string Name { get; set; }
    }

    public class BrandEditDtoValidator : AbstractValidator<BrandEditDto>
    {
        public BrandEditDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MinimumLength(2).MaximumLength(35);
        }
    }
}
