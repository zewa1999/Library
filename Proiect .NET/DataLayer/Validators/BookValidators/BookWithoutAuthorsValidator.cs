using FluentValidation;
using Library.DataLayer.Validators;
using Library.DomainLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect_.NET.DataLayer.Validators.BookValidators
{
    public class BookWithoutAuthorsValidator : AbstractValidator<Book>
    {
        public BookWithoutAuthorsValidator()
        {
            RuleFor(b => b.Title)
                .NotNull().WithMessage("Null {PropertyName}")
                .NotEmpty().WithMessage("{PropertyName} is Empty")
                .Length(2, 50).WithMessage("Lenght of {PropertyName} Invalid")
                .Must(this.BeAValidName).WithMessage("{PropertyName} contains invalid characters");

            RuleFor(b => b.Type)
                .NotNull().WithMessage("Null {PropertyName}")
                .NotEmpty().WithMessage("{PropertyName} is Empty")
                .Length(2, 50).WithMessage("Lenght of {PropertyName} Invalid")
                .Must(this.BeAValidName).WithMessage("{PropertyName} contains invalid characters");

            RuleFor(b => b.IsBorrowed)
                .NotNull().WithMessage("Null {PropertyName}");
            RuleFor(b => b.LecturesOnlyBook)
                .NotNull().WithMessage("Null {PropertyName}");

            RuleFor(b => b.Authors)
                .NotNull().WithMessage("Null {PropertyName}");

            RuleForEach(b => b.Authors).ChildRules(author =>
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

            RuleFor(b => b.Editions)
                .NotNull().WithMessage("Null {PropertyName}")
                .Must(this.HaveEntities).WithMessage("{PropertyName} is Empty");
            RuleFor(b => b.Domains)
                .NotNull().WithMessage("Null {PropertyName}")
                .Must(this.HaveEntities).WithMessage("{PropertyName} is Empty");
            RuleForEach(b => b.Editions).SetValidator(new EditionValidator());
            RuleForEach(b => b.Domains).SetValidator(new DomainValidator());
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
            return name.All(Char.IsLetter);
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