// ***********************************************************************
// Assembly         : Library.DomainLayer
// Author           : costa
// Created          : 12-07-2021
//
// Last Modified By : costa
// Last Modified On : 12-07-2021
// ***********************************************************************
// <copyright file="LibrarianValidator.cs" company="Library.DomainLayer">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace Library.DomainLayer.Validators
{
    using FluentValidation;
    using Library.DomainLayer.Person;

    /// <summary>
    /// Class LibrarianValidator.
    /// Implements the <see cref="FluentValidation.AbstractValidator{Library.DomainLayer.Person.Librarian}" />
    /// </summary>
    /// <seealso cref="FluentValidation.AbstractValidator{Library.DomainLayer.Person.Librarian}" />
    public class LibrarianValidator : AbstractValidator<Librarian>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LibrarianValidator"/> class.
        /// </summary>
        public LibrarianValidator()
        {
            Include(new BorrowerValidator());
        }
    }
}