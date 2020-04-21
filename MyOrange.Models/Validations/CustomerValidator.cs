using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyOrange.Models.Validations
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(p => p.FirstName).Length(3, 50).NotEmpty();
            RuleFor(p => p.LastName).Length(3, 50).NotEmpty();
            RuleFor(p => p.Email).EmailAddress().NotEmpty();
        }
    }
}
