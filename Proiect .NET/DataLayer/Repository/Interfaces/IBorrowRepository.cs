// <copyright file="IBorrowRepository.cs" company="Transilvania University of Brasov">
// Costache Stelian-Andrei
// </copyright>

/// <summary>
/// The Interfaces namespace.
/// </summary>
namespace Library.DataLayer.Interfaces
{
    using Library.DomainLayer;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Interface for the borrow controller.
    /// </summary>
    public interface IBorrowRepository : IRepository<Borrow>
    {
        /// <summary>
        /// Gets the first borrow date.
        /// </summary>
        /// <param name="id"> The identifier. </param>
        /// <returns> DateTime. </returns>
        public DateTime GetFirstBorrowDate(int id);

        /// <summary>
        /// Gets the number of borrows today.
        /// </summary>
        /// <param name="id"> The identifier. </param>
        /// /// <returns> Int. </returns>
        public int GetNumberOfBorrowsToday(int id);

        /// <summary>
        /// Gets the books between past months and present.
        /// </summary>
        /// <param name="months"> The months. </param>
        /// /// <returns> IEnumerable<Borrow>. </returns>
        public IEnumerable<Borrow> GetBooksBetweenPastMonthsAndPresent(int months);
    }
}