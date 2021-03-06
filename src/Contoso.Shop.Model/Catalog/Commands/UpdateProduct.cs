﻿using Contoso.Shop.Model.Shared;
using FluentValidation;
using MediatR;

namespace Contoso.Shop.Model.Catalog.Commands
{
    public class UpdateProduct : IRequest<Result<Product>>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public int DepartamentId { get; set; }

        public class Validator : AbstractValidator<UpdateProduct>
        {
            public Validator()
            {
                RuleFor(x => x.Id).NotNull();
                RuleFor(x => x.Title).NotEmpty().Length(3, 50);
                RuleFor(x => x.ShortDescription).NotEmpty().Length(3, 100);
                RuleFor(x => x.Price).NotNull().GreaterThan(0);
                RuleFor(x => x.Quantity).NotNull();
                RuleFor(x => x.DepartamentId).NotNull().GreaterThan(0);
            }
        }
    }

}