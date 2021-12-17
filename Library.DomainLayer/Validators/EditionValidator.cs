// ***********************************************************************
// Assembly         : Library.DomainLayer
// Author           : costa
// Created          : 12-07-2021
//
// Last Modified By : costa
// Last Modified On : 12-07-2021
// ***********************************************************************
// <copyright file="EditionValidator.cs" company="Library.DomainLayer">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace Library.DomainLayer.Validators
{
    using FluentValidation;

    /// <summary>
    /// Class EditionValidator.
    /// Implements the <see cref="FluentValidation.AbstractValidator{Library.DomainLayer.Edition}" />
    /// </summary>
    /// <seealso cref="FluentValidation.AbstractValidator{Library.DomainLayer.Edition}" />
    public class EditionValidator : AbstractValidator<Edition>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EditionValidator"/> class.
        /// </summary>
        public EditionValidator()
        {
            RuleFor(e => e.Publisher)
                .NotEmpty().WithMessage("{PropertyName} is Empty")
                .Length(2, 50).WithMessage("Lenght of {PropertyName} Invalid");

            RuleFor(e => e.Year)
                  .NotEmpty().WithMessage("{PropertyName} is Empty")
                  .Length(0, 4).WithMessage("Lenght of {PropertyName} Invalid");

            RuleFor(e => e.EditionNumber)
                .NotEmpty().WithMessage("{PropertyName} is Empty");

            RuleFor(e => e.NumberOfPages)
                  .NotEmpty().WithMessage("{PropertyName} is Empty");
        }
    }
}