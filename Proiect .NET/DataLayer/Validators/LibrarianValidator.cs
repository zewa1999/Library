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
    using Library.DomainLayer.Person;

    /// <summary>
    /// Class LibrarianValidator.
    /// Implements the <see cref="FluentValidation.AbstractValidator{Library.DomainLayer.Person.Librarian}" />
    /// </summary>
    /// <seealso cref="FluentValidation.AbstractValidator{Library.DomainLayer.Person.Librarian}" />
    public class LibrarianValidator : AbstractValidator<Librarian>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LibrarianValidator" /> class.
        /// </summary>
        /// <param name="propertiesRepository">The properties repository.</param>
        public LibrarianValidator(IPropertiesRepository propertiesRepository)
        {
            Include(new BorrowerValidator(propertiesRepository));
        }
    }
}