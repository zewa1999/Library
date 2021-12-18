// ***********************************************************************
// Assembly         : Library.DomainLayer
// Author           : costa
// Created          : 11-25-2021
//
// Last Modified By : costa
// Last Modified On : 12-15-2021
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
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the parent domain.
        /// </summary>
        /// <value>The parent domain.</value>
        public Domain? ParentDomain { get; set; }

        /// <summary>
        /// Gets or sets the children domains.
        /// </summary>
        /// <value>The children domains.</value>
        public virtual ICollection<Domain> ChildrenDomains { get; set; }
    }
}