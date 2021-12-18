// ***********************************************************************
// Assembly         : Library.DomainLayer
// Author           : costa
// Created          : 11-25-2021
//
// Last Modified By : costa
// Last Modified On : 12-08-2021
// ***********************************************************************
// <copyright file="Borrow.cs" company="Library.DomainLayer">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Library.DomainLayer.Person;

namespace Library.DomainLayer
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Class Borrow.
    /// </summary>
    public class Borrow
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the borrower.
        /// </summary>
        /// <value>The borrower.</value>
        [Required]
        public Borrower Borrower { get; set; }

        /// <summary>
        /// Gets or sets the borrowed books.
        /// </summary>
        /// <value>The borrowed books.</value>
        [Required]
        public virtual ICollection<Book> BorrowedBooks { get; set; }
    }
}