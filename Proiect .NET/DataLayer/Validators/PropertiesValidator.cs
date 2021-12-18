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
    using Library.DomainLayer;

    /// <summary>
    /// Class PropertiesModelValidator.
    /// Implements the <see cref="FluentValidation.AbstractValidator{Library.DomainLayer.Properties}" />
    /// </summary>
    /// <seealso cref="FluentValidation.AbstractValidator{Library.DomainLayer.Properties}" />
    public class PropertiesValidator : AbstractValidator<Properties>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PropertiesValidator" /> class.
        /// </summary>
        /// <param name="propertiesRepository">The properties repository.</param>
        public PropertiesValidator(IPropertiesRepository propertiesRepository)
        {
            this.RuleFor(p => p.Domenii)
                .GreaterThanOrEqualTo(1);
            this.RuleFor(p => p.NrMaximCartiImprumutate)
                .GreaterThanOrEqualTo(1);
            this.RuleFor(p => p.Perioada);
            this.RuleFor(p => p.NrMaximCartiImprumutateAcelasiDomeniu)
                .GreaterThanOrEqualTo(1);
        }
    }
}