// <copyright file="Properties.cs" company="Transilvania University of Brasov">
// Costache Stelian-Andrei
// </copyright>

namespace Library.DomainLayer
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Class PropertiesModel.
    /// </summary>
    public class Properties
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the domenii.
        /// </summary>
        /// <value>The domenii.</value>
        public int? DOMENII { get; set; }

        /// <summary>
        /// Gets or sets the numar maxim carti.
        /// </summary>
        /// <value>The numar maxim carti.</value>
        public int? NMC { get; set; }

        /// <summary>
        /// Gets or sets the l.
        /// </summary>
        /// <value>The l.</value>
        public int? L { get; set; }

        /// <summary>
        /// Gets or sets the perioada.
        /// </summary>
        /// <value>The perioada.</value>
        public int? PER { get; set; }

        /// <summary>
        /// Gets or sets the nr maxim carti imprumutate.
        /// </summary>
        /// <value>The nr maxim carti imprumutate.</value>
        public int? C { get; set; }

        /// <summary>
        /// Gets or sets the nr maxim carti imprumutate acelasi domeniu.
        /// </summary>
        /// <value>The nr maxim carti imprumutate acelasi domeniu.</value>
        public int? D { get; set; }

        /// <summary>
        /// Gets or sets the limita maxima imprumut.
        /// </summary>
        /// <value>The limita maxima imprumut.</value>
        public int? LIM { get; set; }

        /// <summary>
        /// Gets or sets the delta.
        /// </summary>
        /// <value>The delta.</value>
        public int? DELTA { get; set; }

        /// <summary>
        /// Gets or sets the numar carti imprumutate zilnic.
        /// </summary>
        /// <value> The number. </value>
        public int? NCZ { get; set; }

        /// <summary>
        /// Gets or sets the persimp.
        /// </summary>
        /// <value>The persimp.</value>
        public int? PERSIMP { get; set; }
    }
}