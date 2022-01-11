// <copyright file="BaseDomainValidator.cs" company="Transilvania University of Brasov">
// Costache Stelian-Andrei
// </copyright>

namespace Library.DataLayer.Validators
{
    using FluentValidation;
    using Library.DomainLayer;

    public class BaseDomainValidator : AbstractValidator<Domain>
    {
        public BaseDomainValidator()
        {
            this.RuleFor(d => d.Name)
               .NotNull().WithMessage("Null {PropertyName}")
               .NotEmpty().WithMessage("{PropertyName} is Empty")
               .Length(2, 50).WithMessage("Lenght of {PropertyName} Invalid");

            this.RuleFor(b => b.ChildrenDomains)
                    .NotNull().WithMessage("Null {PropertyName}");
        }
    }
}