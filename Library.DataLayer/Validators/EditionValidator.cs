// ***********************************************************************
// Assembly         : Library.DomainLayer
// Author           : costa
// Created          : 12-07-2021
//
// Last Modified By : costa
// Last Modified On : 12-18-2021
// ***********************************************************************
// <copyright file="EditionValidator.cs" Company Name="Transilvania University of Brasov">
//    "Copyright (c) Costache Stelian-Andrei. All rights reserved." #
// </copyright>
// <summary></summary>
// ***********************************************************************

/// <summary>
/// The Validators namespace.
/// </summary>
namespace Library.DataLayer.Validators
{
    using FluentValidation;
    using Library.DataLayer.Interfaces;
    using Library.DomainLayer;

    /// <summary>
    /// Class EditionValidator.
    /// Implements the <see cref="FluentValidation.AbstractValidator{Library.DomainLayer.Edition}" />
    /// </summary>
    /// <seealso cref="FluentValidation.AbstractValidator{Library.DomainLayer.Edition}" />
    public class EditionValidator : AbstractValidator<Edition>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EditionValidator" /> class.
        /// </summary>
        /// <param name="propertiesRepository">The properties repository.</param>
        public EditionValidator(IPropertiesRepository propertiesRepository)
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