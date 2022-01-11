// <copyright file="BorrowRepository.cs" company="Transilvania University of Brasov">
// Costache Stelian-Andrei
// </copyright>

namespace Library.DataLayer.Concretes
{
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
        /// <summary>
        /// Gets the books between past months and present.
        /// </summary>
        /// <param name="months"> The months. </param>
        public IEnumerable<Borrow> GetBooksBetweenPastMonthsAndPresent(int months)
        {
            DateTime pastMonth = DateTime.Now.AddMonths(months * -1);
            try
            {
                return this.ctx.Borrow.Where(x => x.BorrowDate >= pastMonth).Select(x => x).ToList();
            }
            catch (Exception ex)
            {
                this.logger.Error(ex.Message + "The query could not been made!");
            }

            return new List<Borrow>();
        }

        /// <summary>
        /// Gets the first borrow date.
        /// </summary>
        /// <param name="id"> The identifier. </param>
        public DateTime GetFirstBorrowDate(int id)
        {
            var minDate = DateTime.MaxValue;

            try
            {
                foreach (var borrow in this.ctx.Borrow)
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
                this.logger.Error(ex.Message + "Returning DateTime.MaxValue!");
            }

            return minDate;
        }

        /// <summary>
        /// Gets the number of borrows today.
        /// </summary>
        /// <param name="id"> The identifier. </param>
        public int GetNumberOfBorrowsToday(int id)
        {
            var numberOfBorrowsToday = 0;
            var todayDate = DateTime.Today;
            try
            {
                foreach (var borrow in this.ctx.Borrow)
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
                this.logger.Error(ex.Message + "Returning 0");
            }
            return 0;
        }
    }
}