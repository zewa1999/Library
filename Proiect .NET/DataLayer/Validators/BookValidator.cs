// <company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

/// <summary>
/// The Validators namespace.
/// </summary>
namespace Library.DataLayer.Validators
{
    using FluentValidation;
    using Library.DomainLayer;
    using System;
    using System.Linq;

    /// <summary>
    /// Class BookValidator.
    /// Implements the <see cref="FluentValidation.AbstractValidator{Library.DomainLayer.Book}" />.
    /// </summary>
    /// <seealso cref="FluentValidation.AbstractValidator{Library.DomainLayer.Book}" />.
    public class BookValidator : AbstractValidator<Book>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BookValidator" /> class.
        /// </summary>
        /// <param name="propertiesRepository">The properties repository.</param>
        public BookValidator()
        {

            RuleFor(b => b.Title)
                .NotNull().WithMessage("Null {PropertyName}")
                .NotEmpty().WithMessage("{PropertyName} is Empty")
                .Length(2, 50).WithMessage("Lenght of {PropertyName} Invalid")
                .Must(BeAValidName).WithMessage("{PropertyName} contains invalid characters");

            RuleFor(b => b.Type)
                .NotNull().WithMessage("Null {PropertyName}")
                .NotEmpty().WithMessage("{PropertyName} is Empty")
                .Length(2, 50).WithMessage("Lenght of {PropertyName} Invalid")
                .Must(BeAValidName).WithMessage("{PropertyName} contains invalid characters");

            RuleFor(b => b.IsBorrowed)
                .NotNull().WithMessage("Null {PropertyName}");
            RuleFor(b => b.LecturesOnlyBook)
                .NotNull().WithMessage("Null {PropertyName}");

            RuleForEach(b => b.Authors).ChildRules(author =>
            {
                author.RuleFor(b => b.FirstName)
                .NotNull().WithMessage("Null {PropertyName}")
                .NotEmpty().WithMessage("{PropertyName} is Empty")
                .Length(2, 50).WithMessage("Lenght of {PropertyName} Invalid")
                .Must(BeAValidName).WithMessage("{PropertyName} contains invalid characters");

                author.RuleFor(b => b.LastName)
                    .NotNull().WithMessage("Null {PropertyName}")
                    .NotEmpty().WithMessage("{PropertyName} is Empty")
                    .Length(2, 50).WithMessage("Lenght of {PropertyName} Invalid")
                    .Must(BeAValidName).WithMessage("{PropertyName} contains invalid characters");
            });

            RuleForEach(b => b.Editions).SetValidator(new EditionValidator());
            RuleForEach(b => b.Domains).SetValidator(new DomainValidator());
        }

        /// <summary>
        /// Bes the name of a valid.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        protected bool BeAValidName(string name)
        {
            name = name.Replace(" ", "");
            name = name.Replace("-", "");
            return name.All(Char.IsLetter);
        }
    }
}