// <copyright file="DomainValidator.cs" company="Transilvania University of Brasov">
// Costache Stelian-Andrei
// </copyright>

/// <summary>
/// The Validators namespace.
/// </summary>
namespace Library.DataLayer.Validators
{
    using FluentValidation;
    using Library.DomainLayer;
    using System.Collections.Generic;

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
        public DomainValidator()//x)
        {
            //https://stackoverflow.com/questions/55804470/fluentvalidation-recursive-list-causes-stack-overflow

            // singleton cu lista emoty

            // adaugi x in lista

            this.RuleFor(d => d.Name)
                .NotNull().WithMessage("Null {PropertyName}")
                .NotEmpty().WithMessage("{PropertyName} is Empty")
                .Length(2, 50).WithMessage("Lenght of {PropertyName} Invalid");

            // Nu stiu cum sa fac aici ca sa nu fie dependinta circulara
            //    RuleFor(d => d.Name)
            //    .NotNull().WithMessage("Null {PropertyName}")
            //    .NotEmpty().WithMessage("{PropertyName} is Empty")
            //    .Length(2, 50).WithMessage("Lenght of {PropertyName} Invalid");

            //RuleFor(d => d.ParentDomain).SetInheritanceValidator(v =>  // daca v nu e in lista...
            //{
            //    v.Add<Domain>(new DomainValidator());
            //});

            this.RuleFor(b => b.ChildrenDomains)
                .NotNull().WithMessage("Null {PropertyName}");
            //.Must(HaveEntities).WithMessage("{PropertyName} is Empty");

            //RuleForEach(b => b.ChildrenDomains).ChildRules(domain =>
            //{
            //    domain.RuleFor(d => d.Name)
            //     .NotNull().WithMessage("Null {PropertyName}")
            //     .NotEmpty().WithMessage("{PropertyName} is Empty")
            //     .Length(2, 50).WithMessage("Lenght of {PropertyName} Invalid");
            //});
        }

        /// <summary>
        /// Haves the entities.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entities">The entities.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        protected bool HaveEntities<T>(ICollection<T> entities)
        {
            if (entities == null || entities.Count == 0)
            {
                return false;
            }

            return true;
        }
    }
}