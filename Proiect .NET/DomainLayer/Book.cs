// ***********************************************************************
// Assembly         : Library.DomainLayer
// Author           : costa
// Created          : 11-25-2021
//
// Last Modified By : costa
// Last Modified On : 12-15-2021
// ***********************************************************************
// <copyright file="Book.cs" company="Library.DomainLayer">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Library.DomainLayer
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Class Book.
    /// </summary>
    public class Book
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>The title.</value>
        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is borrowable.
        /// </summary>
        /// <value><c>true</c> if this instance is borrowable; otherwise, <c>false</c>.</value>
        [Required]
        public bool IsBorrowable { get; set; }

        /// <summary>
        /// Gets or sets the authors.
        /// </summary>
        /// <value>The authors.</value>
        [Required]
        public virtual ICollection<Author> Authors { get; set; }

        /// <summary>
        /// Gets or sets the domains.
        /// </summary>
        /// <value>The domains.</value>
        [Required]
        public virtual ICollection<Domain> Domains { get; set; }

        /// <summary>
        /// Gets or sets the editions.
        /// </summary>
        /// <value>The editions.</value>
        [Required]
        public virtual ICollection<Edition> Editions { get; set; }
    }
}