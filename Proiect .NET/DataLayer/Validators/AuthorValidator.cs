// <company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

/// <summary>
/// The Validators namespace.
/// </summary>
namespace Library.DataLayer.Validators
{
    using FluentValidation;
    using Library.DataLayer.Interfaces;
    using Library.DomainLayer;
    using System;
    using System.Linq;

    /// <summary>
    /// Class AuthorValidator.
    /// Implements the <see cref="FluentValidation.AbstractValidator{Author}" />
    /// </summary>
    /// <seealso cref="FluentValidation.AbstractValidator{Library.DomainLayer.Author}" />
    public class AuthorValidator : AbstractValidator<Author>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AuthorValidator" /> class.
        /// </summary>
        /// <param name="propertiesRepository">The properties repository.</param>
        public AuthorValidator(IPropertiesRepository propertiesRepository)
        {
            RuleFor(b => b.FirstName)
                .NotEmpty().WithMessage("{PropertyName} is Empty")
                .Length(2, 50).WithMessage("Lenght of {PropertyName} Invalid")
                .Must(BeAValidName).WithMessage("{PropertyName} contains invalid characters");

            RuleFor(b => b.LastName)
                .NotEmpty().WithMessage("{PropertyName} is Empty")
                .Length(2, 50).WithMessage("Lenght of {PropertyName} Invalid")
                .Must(BeAValidName).WithMessage("{PropertyName} contains invalid characters");
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