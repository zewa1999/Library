// ***********************************************************************
// Assembly         : Library.DomainLayer
// Author           : costa
// Created          : 12-06-2021
//
// Last Modified By : costa
// Last Modified On : 12-06-2021
// ***********************************************************************
// <copyright file="Account.cs" company="Library.DomainLayer">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace Library.DomainLayer.Person
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Class Account.
    /// </summary>
    public class Account
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the phone number.
        /// </summary>
        /// <value>The phone number.</value>
        [Required]
        [StringLength(10)]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>The email.</value>
        [Required]
        [StringLength(45)]
        public string Email { get; set; }
    }
}