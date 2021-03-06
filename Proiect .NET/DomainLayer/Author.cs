// <copyright file="Author.cs" company="Transilvania University of Brasov">
// Costache Stelian-Andrei
// </copyright>

namespace Library.DomainLayer
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Class Author.
    /// </summary>
    public class Author
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>The first name.</value>
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>The last name.</value>
        [Required]
        [StringLength(50)]
        public string LastName { get; set; }
    }
}