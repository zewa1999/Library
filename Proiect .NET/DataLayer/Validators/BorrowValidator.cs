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
    using Library.DomainLayer.Person;

    /// <summary>
    /// Class BorrowValidator.
    /// Implements the <see cref="FluentValidation.AbstractValidator{Library.DomainLayer.Borrow}" />
    /// </summary>
    /// <seealso cref="FluentValidation.AbstractValidator{Library.DomainLayer.Borrow}" />
    public class BorrowValidator : AbstractValidator<Borrow>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BorrowValidator" /> class.
        /// </summary>
        /// <param name="propertiesRepository">The properties repository.</param>
        public BorrowValidator(IPropertiesRepository propertiesRepository)
        {
            RuleFor(b => b.Borrower).SetInheritanceValidator(v =>
            {
                v.Add<Borrower>(new BorrowerValidator(propertiesRepository));
            });

            RuleForEach(b => b.BorrowedBooks).SetValidator(new BookValidator(propertiesRepository));
        }
    }
}