// <copyright file="BorrowValidator.cs" company="Transilvania University of Brasov">
// Costache Stelian-Andrei
// </copyright>

/// <summary>
/// The Validators namespace.
/// </summary>
namespace Library.DataLayer.Validators
{
    using FluentValidation;
    using Library.DomainLayer;
    using Library.DomainLayer.Person;
    using System.Collections.Generic;

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
        public BorrowValidator()
        {
            this.RuleFor(b => b.Borrower).SetInheritanceValidator(v =>
            {
                v.Add<Borrower>(new BorrowerValidator());
            });

            this.RuleFor(b => b.NoOfTimeExtended)
               .NotNull().WithMessage("Null {PropertyName}")
               .GreaterThanOrEqualTo(1).WithMessage("{PropertyName} error")
               .LessThan(4).WithMessage("{PropertyName} error");
            this.RuleFor(b => b.BorrowDate)
                .NotNull().WithMessage("Complete Date is not a valid date.");
            this.RuleFor(b => b.EndDate)
                .NotNull().WithMessage("Complete Date is not a valid date.");

            this.RuleFor(b => b.BorrowedBooks)
               .NotNull().WithMessage("Null {PropertyName}")
               .Must(this.HaveEntities).WithMessage("{PropertyName} is Empty");

            this.RuleForEach(b => b.BorrowedBooks).SetValidator(new BookValidator());
        }

        /// <summary>
        /// Haves the entities.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entities">The entities.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        protected bool HaveEntities<T>(ICollection<T> entities)
        {
            if (entities == null || entities.Count == 0)
            {
                return false;
            }

            return true;
        }
    }
}