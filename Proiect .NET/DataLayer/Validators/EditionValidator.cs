// <copyright file="EditionValidator.cs" company="Transilvania University of Brasov">
// Costache Stelian-Andrei
// </copyright>

/// <summary>
/// The Validators namespace.
/// </summary>
namespace Library.DataLayer.Validators
{
    using FluentValidation;
    using Library.DomainLayer;

    /// <summary>
    /// Class EditionValidator.
    /// Implements the <see cref="FluentValidation.AbstractValidator{Library.DomainLayer.Edition}" />
    /// </summary>
    /// <seealso cref="FluentValidation.AbstractValidator{Library.DomainLayer.Edition}" />
    public class EditionValidator : AbstractValidator<Edition>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EditionValidator" /> class.
        /// </summary>
        public EditionValidator()
        {
            this.RuleFor(e => e.Publisher)
                .NotNull().WithMessage("Null {PropertyName}")
                .NotEmpty().WithMessage("{PropertyName} is Empty")
                .Length(2, 50).WithMessage("Lenght of {PropertyName} Invalid");

            this.RuleFor(e => e.Year)
                .NotNull().WithMessage("Null {PropertyName}")
                .NotEmpty().WithMessage("{PropertyName} is Empty")
                .Length(0, 4).WithMessage("Lenght of {PropertyName} Invalid");

            this.RuleFor(e => e.EditionNumber)
                .NotNull().WithMessage("Null {PropertyName}")
                .GreaterThan(1).WithMessage("{PropertyName} should be greater than 1");

            this.RuleFor(e => e.NumberOfPages)
                .NotNull().WithMessage("Null {PropertyName}")
                .GreaterThan(1).WithMessage("{PropertyName} should be greater than 1");
        }
    }
}