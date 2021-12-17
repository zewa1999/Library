// ***********************************************************************
// Assembly         : Library.DomainLayer
// Author           : costa
// Created          : 12-07-2021
//
// Last Modified By : costa
// Last Modified On : 12-07-2021
// ***********************************************************************
// <copyright file="AccountValidator.cs" company="Library.DomainLayer">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace Library.DomainLayer.Validators
{
    using FluentValidation;
    using Library.DomainLayer.Person;

    /// <summary>
    /// Class AccountValidator.
    /// Implements the <see cref="FluentValidation.AbstractValidator{Library.DomainLayer.Person.Account}" />
    /// </summary>
    /// <seealso cref="FluentValidation.AbstractValidator{Library.DomainLayer.Person.Account}" />
    public class AccountValidator : AbstractValidator<Account>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AccountValidator"/> class.
        /// </summary>
        public AccountValidator()
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