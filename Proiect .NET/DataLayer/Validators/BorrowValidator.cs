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
        public BorrowValidator()
        {
            RuleFor(b => b.Borrower).SetInheritanceValidator(v =>
            {
                v.Add<Borrower>(new BorrowerValidator());
            });

            RuleFor(b => b.NoOfTimeExtended)
               .NotNull().WithMessage("Null {PropertyName}")
               .LessThan(4);
            RuleFor(b => b.BorrowDate)
                .NotNull().WithMessage("Complete Date is not a valid date.");
            RuleFor(b => b.EndDate)
                .NotNull().WithMessage("Complete Date is not a valid date.");

            RuleForEach(b => b.BorrowedBooks).SetValidator(new BookValidator());
        }
    }
}