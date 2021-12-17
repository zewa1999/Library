// ***********************************************************************
// Assembly         : Library.DomainLayer
// Author           : costa
// Created          : 12-08-2021
//
// Last Modified By : costa
// Last Modified On : 12-08-2021
// ***********************************************************************
// <copyright file="DomainValidator.cs" company="Library.DomainLayer">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace Library.DomainLayer.Validators
{
    using FluentValidation;

    /// <summary>
    /// Class DomainValidator.
    /// Implements the <see cref="FluentValidation.AbstractValidator{Library.DomainLayer.Domain}" />
    /// </summary>
    /// <seealso cref="FluentValidation.AbstractValidator{Library.DomainLayer.Domain}" />
    public class DomainValidator : AbstractValidator<Domain>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DomainValidator"/> class.
        /// </summary>
        public DomainValidator()
        {
            RuleFor(d => d.Name)
                .NotEmpty().WithMessage("{PropertyName} is Empty")
                .Length(2, 50).WithMessage("Lenght of {PropertyName} Invalid");

            RuleFor(d => d.ParentDomain).SetInheritanceValidator(v =>
            {
                v.Add<Domain>(new DomainValidator());
            });

            RuleForEach(d => d.ChildrenDomains).SetValidator(new DomainValidator());
        }
    }
}