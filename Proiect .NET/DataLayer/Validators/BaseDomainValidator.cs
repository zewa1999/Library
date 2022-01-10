using FluentValidation;
using Library.DomainLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect_.NET.DataLayer.Validators
{
    public class BaseDomainValidator : AbstractValidator<Domain>
    {
        public BaseDomainValidator()
        {
            RuleFor(d => d.Name)
               .NotNull().WithMessage("Null {PropertyName}")
               .NotEmpty().WithMessage("{PropertyName} is Empty")
               .Length(2, 50).WithMessage("Lenght of {PropertyName} Invalid");

            RuleFor(b => b.ChildrenDomains)
                    .NotNull().WithMessage("Null {PropertyName}");
        }
    }
}