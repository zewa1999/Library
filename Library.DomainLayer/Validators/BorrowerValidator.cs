// ***********************************************************************
// Assembly         : Library.DomainLayer
// Author           : costa
// Created          : 12-07-2021
//
// Last Modified By : costa
// Last Modified On : 12-08-2021
// ***********************************************************************
// <copyright file="BorrowerValidator.cs" company="Library.DomainLayer">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace Library.DomainLayer.Validators
{
    using FluentValidation;
    using Library.DomainLayer.Person;
    using System;
    using System.Linq;

    /// <summary>
    /// Class BorrowerValidator.
    /// Implements the <see cref="FluentValidation.AbstractValidator{Library.DomainLayer.Person.Borrower}" />
    /// </summary>
    /// <seealso cref="FluentValidation.AbstractValidator{Library.DomainLayer.Person.Borrower}" />
    public class BorrowerValidator : AbstractValidator<Borrower>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BorrowerValidator"/> class.
        /// </summary>
        public BorrowerValidator()
        {
            RuleFor(b => b.FirstName)
                .NotEmpty().WithMessage("{PropertyName} is Empty")
                .Length(2, 50).WithMessage("Lenght of {PropertyName} Invalid")
                .Must(BeAValidName).WithMessage("{PropertyName} contains invalid characters");

            RuleFor(b => b.LastName)
                .NotEmpty().WithMessage("{PropertyName} is Empty")
                .Length(2, 50).WithMessage("Lenght of {PropertyName} Invalid")
                .Must(BeAValidName).WithMessage("{PropertyName} contains invalid characters");

            RuleFor(b => b.Address)
                .NotEmpty().WithMessage("{PropertyName} is Empty")
                .Length(2, 80).WithMessage("Lenght of {PropertyName} Invalid");

            RuleFor(b => b.LastName)
                .NotEmpty().WithMessage("{PropertyName} is Empty")
                .Length(2, 50).WithMessage("Lenght of {PropertyName} Invalid")
                .Must(BeAValidName).WithMessage("{PropertyName} contains invalid characters");

            RuleFor(b => b.Account).SetInheritanceValidator(v =>
            {
                v.Add<Account>(new AccountValidator());
            });
        }

        /// <summary>
        /// Bes the name of a valid.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        protected bool BeAValidName(string name)
        {
            name = name.Replace(" ", "");
            name = name.Replace("-", "");
            return name.All(Char.IsLetter);
        }
    }
}