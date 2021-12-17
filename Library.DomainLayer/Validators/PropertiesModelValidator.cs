// ***********************************************************************
// Assembly         : Library.DomainLayer
// Author           : costa
// Created          : 12-08-2021
//
// Last Modified By : costa
// Last Modified On : 12-08-2021
// ***********************************************************************
// <copyright file="PropertiesModelValidator.cs" company="Library.DomainLayer">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace Library.DomainLayer.Validators
{
    using FluentValidation;

    /// <summary>
    /// Class PropertiesModelValidator.
    /// Implements the <see cref="FluentValidation.AbstractValidator{Library.DomainLayer.PropertiesModel}" />
    /// </summary>
    /// <seealso cref="FluentValidation.AbstractValidator{Library.DomainLayer.PropertiesModel}" />
    public class PropertiesModelValidator : AbstractValidator<PropertiesModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PropertiesModelValidator"/> class.
        /// </summary>
        public PropertiesModelValidator()
        {
            RuleFor(p => p.Domenii)
                .GreaterThanOrEqualTo(1);
            RuleFor(p => p.NrMaximCartiImprumutate)
                .GreaterThanOrEqualTo(1);
            RuleFor(p => p.Perioada);
            RuleFor(p => p.NrMaximCartiImprumutateAcelasiDomeniu)
                .GreaterThanOrEqualTo(1);
        }
    }
}