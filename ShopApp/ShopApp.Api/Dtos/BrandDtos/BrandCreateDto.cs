using FluentValidation;
using System.ComponentModel.DataAnnotations;

namespace ShopApp.Api.Dtos.BrandDtos
{
    public class BrandCreateDto
    {
        public string Name { get; set; }
    }

    public class BrandCreateDtoValidatior : AbstractValidator<BrandCreateDto>
    {
        public BrandCreateDtoValidatior()
        {
            RuleFor(x => x.Name)
                .NotEmpty().MinimumLength(2).MaximumLength(35);
        }
    }
}
