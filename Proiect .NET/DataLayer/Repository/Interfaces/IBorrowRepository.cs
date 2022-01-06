// <company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
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
        public DateTime GetFirstBorrowDate(int id);
        public int GetNumberOfBorrowsToday(int id);

        public IEnumerable<Borrow> GetBooksBetweenPastMonthsAndPresent(int months);
    }
}