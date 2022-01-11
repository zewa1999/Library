// <copyright file="BookWithoutAuthorsValidator.cs" company="Transilvania University of Brasov">
// Costache Stelian-Andrei
// </copyright>

namespace Library.DataLayer.Validators
{
    using FluentValidation;
    using Library.DomainLayer;
    using System.Collections.Generic;
    using System.Linq;

    public class BookWithoutAuthorsValidator : AbstractValidator<Book>
    {
        public BookWithoutAuthorsValidator()
        {
            this.RuleFor(b => b.Title)
                .NotNull().WithMessage("Null {PropertyName}")
                .NotEmpty().WithMessage("{PropertyName} is Empty")
                .Length(2, 50).WithMessage("Lenght of {PropertyName} Invalid")
                .Must(this.BeAValidName).WithMessage("{PropertyName} contains invalid characters");

            this.RuleFor(b => b.Type)
                .NotNull().WithMessage("Null {PropertyName}")
                .NotEmpty().WithMessage("{PropertyName} is Empty")
                .Length(2, 50).WithMessage("Lenght of {PropertyName} Invalid")
                .Must(this.BeAValidName).WithMessage("{PropertyName} contains invalid characters");

            this.RuleFor(b => b.IsBorrowed)
                .NotNull().WithMessage("Null {PropertyName}");
            this.RuleFor(b => b.LecturesOnlyBook)
                .NotNull().WithMessage("Null {PropertyName}");

            this.RuleFor(b => b.Authors)
                .NotNull().WithMessage("Null {PropertyName}");

            this.RuleForEach(b => b.Authors).ChildRules(author =>
            {
                author.RuleFor(b => b.FirstName)
                .NotNull().WithMessage("Null {PropertyName}")
                .NotEmpty().WithMessage("{PropertyName} is Empty")
                .Length(2, 50).WithMessage("Lenght of {PropertyName} Invalid")
                .Must(this.BeAValidName).WithMessage("{PropertyName} contains invalid characters");

                author.RuleFor(b => b.LastName)
                    .NotNull().WithMessage("Null {PropertyName}")
                    .NotEmpty().WithMessage("{PropertyName} is Empty")
                    .Length(2, 50).WithMessage("Lenght of {PropertyName} Invalid")
                    .Must(this.BeAValidName).WithMessage("{PropertyName} contains invalid characters");
            });

            this.RuleFor(b => b.Editions)
                .NotNull().WithMessage("Null {PropertyName}")
                .Must(this.HaveEntities).WithMessage("{PropertyName} is Empty");
            this.RuleFor(b => b.Domains)
                .NotNull().WithMessage("Null {PropertyName}")
                .Must(this.HaveEntities).WithMessage("{PropertyName} is Empty");
            this.RuleForEach(b => b.Editions).SetValidator(new EditionValidator());
            this.RuleForEach(b => b.Domains).SetValidator(new DomainValidator());
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
            name = name.Replace(" ", string.Empty);
            name = name.Replace("-", string.Empty);
            return name.All(char.IsLetter);
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