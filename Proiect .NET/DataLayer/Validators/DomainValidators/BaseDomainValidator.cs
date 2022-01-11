// <copyright file="BaseDomainValidator.cs" company="Transilvania University of Brasov">
// Costache Stelian-Andrei
// </copyright>

namespace Library.DataLayer.Validators
{
    using FluentValidation;
    using Library.DomainLayer;

    /// <summary>
    /// Class BaseDomainValidator.
    /// Implements the <see cref="FluentValidation.AbstractValidator{Library.DomainLayer.Domain}" />.
    /// </summary>
    /// <seealso cref="FluentValidation.AbstractValidator{Library.DomainLayer.Domain}" />
    public class BaseDomainValidator : AbstractValidator<Domain>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseDomainValidator"/> class.
        /// </summary>
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