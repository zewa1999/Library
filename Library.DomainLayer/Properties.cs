// ***********************************************************************
// Assembly         : Library.DomainLayer
// Author           : costa
// Created          : 11-29-2021
//
// Last Modified By : costa
// Last Modified On : 11-29-2021
// ***********************************************************************
// <copyright file="PropertiesModel.cs" company="Library.DomainLayer">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace Library.DomainLayer
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Class PropertiesModel.
    /// </summary>
    ///
    public class Properties
    {
        [Required]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the domenii.
        /// </summary>
        /// <value>The domenii.</value>
        public int Domenii { get; set; }

        /// <summary>
        /// Gets or sets the numar maxim carti.
        /// </summary>
        /// <value>The numar maxim carti.</value>
        public int NumarMaximCarti { get; set; }

        /// <summary>
        /// Gets or sets the perioada.
        /// </summary>
        /// <value>The perioada.</value>
        public int Perioada { get; set; }

        /// <summary>
        /// Gets or sets the nr maxim carti imprumutate.
        /// </summary>
        /// <value>The nr maxim carti imprumutate.</value>
        public int NrMaximCartiImprumutate { get; set; }

        /// <summary>
        /// Gets or sets the nr maxim carti imprumutate acelasi domeniu.
        /// </summary>
        /// <value>The nr maxim carti imprumutate acelasi domeniu.</value>
        public int NrMaximCartiImprumutateAcelasiDomeniu { get; set; }

        /// <summary>
        /// Gets or sets the limita maxima imprumut.
        /// </summary>
        /// <value>The limita maxima imprumut.</value>
        public int LimitaMaximaImprumut { get; set; }

        /// <summary>
        /// Gets or sets the delta.
        /// </summary>
        /// <value>The delta.</value>
        public int Delta { get; set; }

        /// <summary>
        /// Gets or sets the numar carti imprumutate zilnic.
        /// </summary>
        /// <value>The numar carti imprumutate zilnic.</value>
        public int NumarCartiImprumutateZilnic { get; set; }

        /// <summary>
        /// Gets or sets the persimp.
        /// </summary>
        /// <value>The persimp.</value>
        public int Persimp { get; set; }
    }
}