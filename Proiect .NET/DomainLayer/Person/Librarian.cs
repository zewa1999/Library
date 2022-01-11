// <copyright file="Librarian.cs" company="Transilvania University of Brasov">
// Costache Stelian-Andrei
// </copyright>

namespace Library.DomainLayer.Person
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Class Librarian.
    /// Implements the <see cref="Library.DomainLayer.Person.Borrower" />.
    /// </summary>
    /// <seealso cref="Library.DomainLayer.Person.Borrower" />
    public class Librarian : Borrower
    {
        [Required]
        public bool? IsReader { get; set; }
    }
}