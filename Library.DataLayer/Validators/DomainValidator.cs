// ***********************************************************************
// Assembly         : Library.DomainLayer
// Author           : costa
// Created          : 12-08-2021
//
// Last Modified By : costa
// Last Modified On : 12-18-2021
// ***********************************************************************
// <copyright file="DomainValidator.cs" Company Name="Transilvania University of Brasov">
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
    /// Class DomainValidator.
    /// Implements the <see cref="FluentValidation.AbstractValidator{Library.DomainLayer.Domain}" />
    /// </summary>
    /// <seealso cref="FluentValidation.AbstractValidator{Library.DomainLayer.Domain}" />
    public class DomainValidator : AbstractValidator<Domain>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DomainValidator" /> class.
        /// </summary>
        /// <param name="propertiesRepository">The properties repository.</param>
        public DomainValidator(IPropertiesRepository propertiesRepository)
        {
            RuleFor(d => d.Name)
                .NotEmpty().WithMessage("{PropertyName} is Empty")
                .Length(2, 50).WithMessage("Lenght of {PropertyName} Invalid");

            RuleFor(d => d.ParentDomain).SetInheritanceValidator(v =>
            {
                v.Add<Domain>(new DomainValidator(propertiesRepository));
            });

            RuleForEach(d => d.ChildrenDomains).SetValidator(new DomainValidator(propertiesRepository));
        }
    }
}