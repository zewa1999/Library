// <company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
/// <summary>
/// The Concretes namespace.
/// </summary>
namespace Library.DataLayer.Concretes
{
    using Library.DataLayer.DataMapper;
    using Library.DataLayer.Interfaces;
    using Library.DomainLayer;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Methods for the borrow controller.
    /// </summary>
    public class BorrowRepository : BaseRepository<Borrow>, IBorrowRepository
    {
        public IEnumerable<Borrow> GetBooksBetweenPastMonthsAndPresent(int months)
        {
            DateTime pastMonth = DateTime.Now.AddMonths(months * -1);
            using (var ctx = new LibraryContext())
            {
                try
                {
                    return ctx.Borrow.Where(x => x.BorrowDate >= pastMonth).Select(x => x).ToList();
                }
                catch (Exception ex)
                {
                    logger.Error(ex.Message + "The query could not been made!");
                }
            }
            return new List<Borrow>();

        }

        public DateTime GetFirstBorrowDate(int id)
        {
            var minDate = DateTime.MaxValue;

            using (var ctx = new LibraryContext())
            {
                try
                {
                    foreach (var borrow in ctx.Borrow)
                    {
                        if (borrow.Borrower.Id == id && borrow.BorrowDate < minDate)
                        {
                            minDate = (DateTime)borrow.BorrowDate;
                        }
                    }

                    return minDate;
                }
                catch (Exception ex)
                {
                    logger.Error(ex.Message + "Returning DateTime.MaxValue!");
                }
            }
            return minDate;
        }

        public int GetNumberOfBorrowsToday(int id)
        {
            var numberOfBorrowsToday = 0;
            var todayDate = DateTime.Today;
            using (var ctx = new LibraryContext())
            {
                try
                {
                    foreach (var borrow in ctx.Borrow)
                    {
                        if (borrow.Borrower.Id == id && borrow.BorrowDate == todayDate)
                        {
                            numberOfBorrowsToday++;
                        }
                    }
                    return numberOfBorrowsToday;
                }
                catch (Exception ex)
                {
                    logger.Error(ex.Message + "Returning 0");
                }
                return 0;
            }
        }
    }
}