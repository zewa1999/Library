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
        public AccountValidator(IPropertiesRepository propertiesRepository)
        {
            RuleFor(a => a.PhoneNumber)
                .NotEmpty().WithMessage("Empty phone number")
                .Length(10).WithMessage("Lenght should be 10")
                .Matches(@"^[2-9]\d{2}-\d{3}-\d{4}$").WithMessage("Please add a valid phone number");

            RuleFor(a => a.Email)
                .EmailAddress().WithMessage("The email is not valid");
        }
    }
}