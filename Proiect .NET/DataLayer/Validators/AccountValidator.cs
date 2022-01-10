// ***********************************************************************
// Assembly         : Library
// Author           : costa
// Created          : 01-06-2022
//
// Last Modified By : costa
// Last Modified On : 01-06-2022
// ***********************************************************************
// <copyright file="AccountValidator.cs" company="Library">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

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
        public AccountValidator()
        {
            RuleFor(a => a.PhoneNumber)
                .NotNull().WithMessage("Null phone number")
                .NotEmpty().WithMessage("Empty phone number")
                .Must(this.DoesNotContainLetters)
                .Length(10).WithMessage("Lenght should be 10");

            RuleFor(a => a.Email)
                .EmailAddress().WithMessage("The email is not valid");
        }

        /// <summary>
        /// Doeses the not contain letters.
        /// </summary>
        /// <param name="phoneNumber">The phone number.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        protected bool DoesNotContainLetters(string phoneNumber)
        {
            if (phoneNumber == null)
                return false;
            return phoneNumber.Any(x => !char.IsLetter(x));
        }
    }
}