// ***********************************************************************
// Assembly         : Library.DomainLayer
// Author           : costa
// Created          : 12-08-2021
//
// Last Modified By : costa
// Last Modified On : 12-18-2021
// ***********************************************************************
// <copyright file="BookValidator.cs" Company Name="Transilvania University of Brasov">
//    "Copyright (c) Costache Stelian-Andrei. All rights reserved." #
// </copyright>
// <summary></summary>
// ***********************************************************************

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
    /// Class BookValidator.
    /// Implements the <see cref="FluentValidation.AbstractValidator{Library.DomainLayer.Book}" />.
    /// </summary>
    /// <seealso cref="FluentValidation.AbstractValidator{Library.DomainLayer.Book}"/>.
    public class BookValidator : AbstractValidator<Book>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BookValidator" /> class.
        /// </summary>
        /// <param name="propertiesRepository">The properties repository.</param>
        public BookValidator(IPropertiesRepository propertiesRepository)
        {
            RuleFor(b => b.Title)
                .NotEmpty().WithMessage("{PropertyName} is Empty")
                .Length(2, 50).WithMessage("Lenght of {PropertyName} Invalid")
                .Must(BeAValidName).WithMessage("{PropertyName} contains invalid characters");

            RuleForEach(b => b.Authors).SetValidator(new AuthorValidator(propertiesRepository));
            RuleForEach(b => b.Editions).SetValidator(new EditionValidator(propertiesRepository));
            RuleForEach(b => b.Domains).SetValidator(new DomainValidator(propertiesRepository));
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