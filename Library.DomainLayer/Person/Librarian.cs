// ***********************************************************************
// Assembly         : Library.DomainLayer
// Author           : costa
// Created          : 11-25-2021
//
// Last Modified By : costa
// Last Modified On : 11-25-2021
// ***********************************************************************
// <copyright file="Librarian.cs" company="Library.DomainLayer">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Library.DomainLayer.Person
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Class Librarian.
    /// Implements the <see cref="Library.DomainLayer.Person.Borrower" />
    /// </summary>
    /// <seealso cref="Library.DomainLayer.Person.Borrower" />
    public class Librarian : Borrower
    {
        /// <summary>
        /// Gets or sets a value indicating whether this instance is reader.
        /// </summary>
        /// <value><c>true</c> if this instance is reader; otherwise, <c>false</c>.</value>
        [Required]
        public bool IsReader { get; set; }
    }
}