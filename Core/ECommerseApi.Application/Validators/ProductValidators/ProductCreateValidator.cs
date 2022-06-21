using ECommerseApi.Application.Dtos.ProductDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerseApi.Application.Validators.ProductValidators
{
    public class ProductCreateValidator : AbstractValidator<Product_Create_Dto>
    {
        public ProductCreateValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Please Enter prduct name");

            RuleFor(p => p.Stock)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Please Enter stock count")
                .Must(s => s >= 0)
                    .WithMessage("Stock count cannot be negative");

            RuleFor(p => p.Price)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Please Enter product price")
                .Must(p => p >= 0)
                    .WithMessage("price cannot be negative");
        }
    }
}
