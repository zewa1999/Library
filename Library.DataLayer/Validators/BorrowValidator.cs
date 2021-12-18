// ***********************************************************************
// Assembly         : Library.DomainLayer
// Author           : costa
// Created          : 12-08-2021
//
// Last Modified By : costa
// Last Modified On : 12-18-2021
// ***********************************************************************
// <copyright file="BorrowValidator.cs" Company Name="Transilvania University of Brasov">
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