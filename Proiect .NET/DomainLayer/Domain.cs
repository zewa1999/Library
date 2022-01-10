// ***********************************************************************
// Assembly         : Library.DomainLayer
// Author           : costa
// Created          : 11-25-2021
//
// Last Modified By : costa
// Last Modified On : 01-06-2022
// ***********************************************************************
// <copyright file="Domain.cs" company="Library.DomainLayer">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Library.DomainLayer
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Class Domain.
    /// </summary>
    public class Domain
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        [StringLength(50)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the parent domain.
        /// </summary>
        /// <value>The parent domain.</value>
        public virtual Domain ParentDomain { get; set; }

        public int? ParentDomainId { get; set; }

        /// <summary>
        /// Gets or sets the children domains.
        /// </summary>
        /// <value>The children domains.</value>
        public virtual ICollection<Domain> ChildrenDomains { get; set; }
    }
}