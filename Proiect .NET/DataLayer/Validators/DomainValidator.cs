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
        public DomainValidator()//x)
        {

            //https://stackoverflow.com/questions/55804470/fluentvalidation-recursive-list-causes-stack-overflow

            // singleton cu lista emoty

            // adaugi x in lista

            RuleFor(d => d.Name)
                .NotNull().WithMessage("Null {PropertyName}")
                .NotEmpty().WithMessage("{PropertyName} is Empty")
                .Length(2, 50).WithMessage("Lenght of {PropertyName} Invalid");

            //Nu stiu cum sa fac aici ca sa nu fie dependinta circulara
            //    RuleFor(d => d.Name)
            //    .NotNull().WithMessage("Null {PropertyName}")
            //    .NotEmpty().WithMessage("{PropertyName} is Empty")
            //    .Length(2, 50).WithMessage("Lenght of {PropertyName} Invalid");

            //RuleFor(d => d.ParentDomain).SetInheritanceValidator(v =>  // daca v nu e in lista...
            //{
            //    v.Add<Domain>(new DomainValidator());
            //});

            RuleForEach(b => b.ChildrenDomains).ChildRules(domain =>
            {
                domain.RuleFor(d => d.Name)
                 .NotNull().WithMessage("Null {PropertyName}")
                 .NotEmpty().WithMessage("{PropertyName} is Empty")
                 .Length(2, 50).WithMessage("Lenght of {PropertyName} Invalid");

                domain.RuleFor(d => d.Name)
                .NotNull().WithMessage("Null {PropertyName}")
                .NotEmpty().WithMessage("{PropertyName} is Empty")
                .Length(2, 50).WithMessage("Lenght of {PropertyName} Invalid");
            });
        }
    }
}