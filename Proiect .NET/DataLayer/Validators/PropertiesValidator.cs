// <company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

/// <summary>
/// The Validators namespace.
/// </summary>
namespace Library.DataLayer.Validators
{
    using FluentValidation;
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
        public PropertiesValidator()
        {
            this.RuleFor(p => p.Domenii)
            .NotNull().WithMessage("Null {PropertyName}")
            .GreaterThanOrEqualTo(1);
            this.RuleFor(p => p.NrMaximCartiImprumutate)
                .NotNull().WithMessage("Null {PropertyName}")
                .GreaterThanOrEqualTo(1);
            this.RuleFor(p => p.Perioada)
                .NotNull().WithMessage("Null {PropertyName}")
                .GreaterThanOrEqualTo(1);
            this.RuleFor(p => p.NrMaximCartiImprumutateAcelasiDomeniu)
                .NotNull().WithMessage("Null {PropertyName}")
                .GreaterThanOrEqualTo(1);
            this.RuleFor(p => p.NumarMaximCarti)
                .NotNull().WithMessage("Null {PropertyName}")
                .GreaterThanOrEqualTo(1);
            this.RuleFor(p => p.L)
                .NotNull().WithMessage("Null {PropertyName}")
                .GreaterThanOrEqualTo(1);
            this.RuleFor(p => p.LimitaMaximaImprumut)
                .NotNull().WithMessage("Null {PropertyName}")
                .GreaterThanOrEqualTo(1);
            this.RuleFor(p => p.Delta)
                .NotNull().WithMessage("Null {PropertyName}")
                .GreaterThanOrEqualTo(1);
            this.RuleFor(p => p.NumarCartiImprumutateZilnic)
                .NotNull().WithMessage("Null {PropertyName}")
                .GreaterThanOrEqualTo(1);
            this.RuleFor(p => p.Persimp)
                .NotNull().WithMessage("Null {PropertyName}")
                .GreaterThanOrEqualTo(1);
        }
    }
}