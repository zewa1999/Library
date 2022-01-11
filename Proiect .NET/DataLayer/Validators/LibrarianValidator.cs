// <copyright file="LibrarianValidator.cs" company="Transilvania University of Brasov">
// Costache Stelian-Andrei
// </copyright>

/// <summary>
/// The Validators namespace.
/// </summary>
namespace Library.DataLayer.Validators
{
    using FluentValidation;
    using Library.DomainLayer.Person;

    /// <summary>
    /// Class LibrarianValidator.
    /// Implements the <see cref="FluentValidation.AbstractValidator{Library.DomainLayer.Person.Librarian}" />.
    /// </summary>
    /// <seealso cref="FluentValidation.AbstractValidator{Library.DomainLayer.Person.Librarian}" />
    public class LibrarianValidator : AbstractValidator<Librarian>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LibrarianValidator" /> class.
        /// </summary>
        public LibrarianValidator()
        {
            this.RuleFor(l => l.IsReader)
                .NotNull().WithMessage("Null {PropertyName}");
            this.Include(new BorrowerValidator());
        }
    }
}