// <copyright file="Edition.cs" company="Transilvania University of Brasov">
// Costache Stelian-Andrei
// </copyright>

namespace Library.DomainLayer
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Class Edition.
    /// </summary>
    public class Edition
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
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
        public int? EditionNumber { get; set; }

        /// <summary>
        /// Gets or sets the number of pages.
        /// </summary>
        /// <value>The number of pages.</value>
        [Required]
        public int? NumberOfPages { get; set; }
    }
}