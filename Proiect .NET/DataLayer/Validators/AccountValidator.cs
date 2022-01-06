// <company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

/// <summary>
/// The Validators namespace.
/// </summary>
namespace Library.DataLayer.Validators
{
    using FluentValidation;
    using Library.DomainLayer.Person;
    using System.Linq;
    /// <summary>
    /// Class AccountValidator.
    /// Implements the <see cref="FluentValidation.AbstractValidator{Account}" />
    /// </summary>
    /// <seealso cref="FluentValidation.AbstractValidator{Account}" />
    public class AccountValidator : AbstractValidator<Account>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AccountValidator" /> class.
        /// </summary>
        /// <param name="propertiesRepository">The properties repository.</param>
        public AccountValidator()
        {
            RuleFor(a => a.PhoneNumber)
                .NotNull().WithMessage("Null phone number")
                .NotEmpty().WithMessage("Empty phone number")
                .Must(DoesNotContainLetters)
                .Length(10).WithMessage("Lenght should be 10");

            RuleFor(a => a.Email)
                .EmailAddress().WithMessage("The email is not valid");

        }
        protected bool DoesNotContainLetters(string phoneNumber)
        {
            if (phoneNumber == null)
                return false;
            return phoneNumber.Any(x => !char.IsLetter(x));
        }
    }
}