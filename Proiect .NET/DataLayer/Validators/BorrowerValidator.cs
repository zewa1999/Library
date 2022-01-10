// ***********************************************************************
// Assembly         : Library
// Author           : costa
// Created          : 01-06-2022
//
// Last Modified By : costa
// Last Modified On : 01-09-2022
// ***********************************************************************
// <copyright file="BorrowerValidator.cs" company="Library">
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
        /// Initializes a new instance of the <see cref="BorrowerValidator" /> class.
        /// </summary>
        public BorrowerValidator()
        {
            RuleFor(b => b.FirstName)
                .NotNull().WithMessage("Null {PropertyName}")
                .NotEmpty().WithMessage("{PropertyName} is Empty")
                .Length(2, 50).WithMessage("Lenght of {PropertyName} Invalid")
                .Must(this.BeAValidName).WithMessage("{PropertyName} contains invalid characters");

            RuleFor(b => b.LastName)
                .NotNull().WithMessage("Null {PropertyName}")
                .NotEmpty().WithMessage("{PropertyName} is Empty")
                .Length(2, 50).WithMessage("Lenght of {PropertyName} Invalid")
                .Must(this.BeAValidName).WithMessage("{PropertyName} contains invalid characters");

            RuleFor(b => b.Address)
                .NotNull().WithMessage("Null {PropertyName}")
                .NotEmpty().WithMessage("{PropertyName} is Empty")
                .Length(2, 80).WithMessage("Lenght of {PropertyName} Invalid");

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
            if (name == null)
                return false;

            name = name.Replace(" ", "");
            name = name.Replace("-", "");
            return name.All(Char.IsLetter);
        }
    }
}