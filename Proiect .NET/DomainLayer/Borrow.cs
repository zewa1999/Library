﻿// ***********************************************************************
// Assembly         : Library.DomainLayer
// Author           : costa
// Created          : 11-25-2021
//
// Last Modified By : costa
// Last Modified On : 01-09-2022
// ***********************************************************************
// <copyright file="Borrow.cs" company="Library.DomainLayer">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Library.DomainLayer.Person;

namespace Library.DomainLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Class Borrow.
    /// </summary>
    public class Borrow
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the borrow date.
        /// </summary>
        /// <value>The borrow date.</value>
        [Required]
        public DateTime? BorrowDate { get; set; }

        /// <summary>
        /// Gets or sets the end date.
        /// </summary>
        /// <value>The end date.</value>
        [Required]
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// Gets or sets the no of time extended.
        /// </summary>
        /// <value>The no of time extended.</value>
        [Required]
        public int? NoOfTimeExtended { get; set; }

        /// <summary>
        /// Gets or sets the borrower.
        /// </summary>
        /// <value>The borrower.</value>
        [Required]
        public virtual Borrower Borrower { get; set; }

        /// <summary>
        /// Gets or sets the borrower identifier.
        /// </summary>
        /// <value>The borrower identifier.</value>
        public int BorrowerId { get; set; }

        /// <summary>
        /// Gets or sets the borrowed books.
        /// </summary>
        /// <value>The borrowed books.</value>
        [Required]
        public virtual ICollection<Book> BorrowedBooks { get; set; }
    }
}