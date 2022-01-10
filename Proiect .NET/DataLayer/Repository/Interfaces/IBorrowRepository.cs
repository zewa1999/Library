// ***********************************************************************
// Assembly         : Library
// Author           : costa
// Created          : 01-06-2022
//
// Last Modified By : costa
// Last Modified On : 01-06-2022
// ***********************************************************************
// <copyright file="IBorrowRepository.cs" company="Library">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
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
        public DateTime GetFirstBorrowDate(int id);

        /// <summary>
        /// Gets the number of borrows today.
        /// </summary>
        /// <param name="id"> The identifier. </param>
        public int GetNumberOfBorrowsToday(int id);

        /// <summary>
        /// Gets the books between past months and present.
        /// </summary>
        /// <param name="months"> The months. </param>
        public IEnumerable<Borrow> GetBooksBetweenPastMonthsAndPresent(int months);
    }
}