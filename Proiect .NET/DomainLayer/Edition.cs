// ***********************************************************************
// Assembly         : Library.DomainLayer
// Author           : costa
// Created          : 11-25-2021
//
// Last Modified By : costa
// Last Modified On : 12-15-2021
// ***********************************************************************
// <copyright file="Edition.cs" company="Library.DomainLayer">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace Library.DomainLayer
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Class Edition.
    /// </summary>
    public class Edition
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the publisher.
        /// </summary>
        /// <value>The publisher.</value>
        [Required]
        [StringLength(50)]
        public string Publisher { get; set; }

        /// <summary>
        /// Gets or sets the year.
        /// </summary>
        /// <value>The year.</value>
        [Required]
        [StringLength(4)]
        public string Year { get; set; }

        /// <summary>
        /// Gets or sets the edition number.
        /// </summary>
        /// <value>The edition number.</value>
        [Required]
        public int EditionNumber { get; set; }

        /// <summary>
        /// Gets or sets the number of pages.
        /// </summary>
        /// <value>The number of pages.</value>
        [Required]
        public int NumberOfPages { get; set; }
    }
}