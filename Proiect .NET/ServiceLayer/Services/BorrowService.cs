// <copyright file="BorrowService.cs" company="Transilvania University of Brasov">
// Costache Stelian-Andrei
// </copyright>

namespace Library.ServiceLayer.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Library.DataLayer.Interfaces;
    using Library.DataLayer.Validators;
    using Library.DomainLayer;
    using Library.DomainLayer.Person;
    using Library.ServiceLayer.IServices;
    using Proiect_.NET.Injection;

    /// <summary>
    /// Class BorrowService.
    /// Implements the <see cref="Library.ServiceLayer.Services.BaseService{Library.DomainLayer.Borrow, Library.DataLayer.Interfaces.IBorrowRepository}" />
    /// Implements the <see cref="Library.ServiceLayer.IServices.IBorrowService" />.
    /// </summary>
    /// <seealso cref="Library.ServiceLayer.Services.BaseService{Library.DomainLayer.Borrow, Library.DataLayer.Interfaces.IBorrowRepository}" />
    /// <seealso cref="Library.ServiceLayer.IServices.IBorrowService" />
    public class BorrowService : BaseService<Borrow, IBorrowRepository, IPropertiesRepository>, IBorrowService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BorrowService" /> class.
        /// </summary>
        /// <param name="borrowRepository">The borrow repository.</param>
        /// <param name="propertiesRepository">The properties repository.</param>
        private readonly IBookRepository bookRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="BorrowService" /> class.
        /// </summary>
        public BorrowService()
             : base(Injector.Create<IBorrowRepository>(), Injector.Create<IPropertiesRepository>())
        {
            this.bookRepository = Injector.Create<IBookRepository>();
            this.Validator = new BorrowValidator();
        }

        /// <summary>
        /// Inserts the specified entity.
        /// </summary>
        /// <param name="entity"> The entity. </param>
        /// <returns> ceva. </returns>
        public override bool Insert(Borrow entity)
        {
            // un imprumut are maxim 1 luna
            var startDate = (DateTime)entity.BorrowDate;
            entity.EndDate = startDate.AddMonths(1);

            var result = this.Validator.Validate(entity);
            if (result.IsValid && this.CheckFlags(entity))
            {
                this.Repository.Insert(entity);
            }
            else
            {
                Utils.LogErrors(result);
                return false;
            }

            return true;
        }

        /// <summary>
        /// Checks if borrow books of the same domain in last l months.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool CheckIfBorrowBooksOfTheSameDomainInLastLMonths(Borrow entity)
        {
            var properties = this.PropertiesRepository.GetLastProperties();

            var d = this.PropertiesRepository.GetLastProperties().D;

            var castedLibrarian = (Librarian)entity.Borrower;

            if (castedLibrarian.IsReader == true)
            {
                d *= 2;
            }

            // iau cartile ce au start date >= datetime.now.months -3 sau enddate > datetime.now.months -3 sau enddate > datetime.now
            var booksInLastLMonths = this.Repository.Get(
                borrow => borrow.BorrowDate >= DateTime.Now.AddMonths(-3) ||
                borrow.EndDate > DateTime.Now.AddMonths(-3) ||
                borrow.EndDate > DateTime.Now,
                borrow => borrow.OrderBy(x => x.Id),
                string.Empty);

            var allBooksInBorrows = booksInLastLMonths.SelectMany(x => x.BorrowedBooks).ToList();

            var domainRepository = Injector.Create<IDomainRepository>();

            var domainDictionary = new Dictionary<int, int>();

            var domains = domainRepository.Get(null, d => d.OrderBy(x => x.Id), string.Empty);

            foreach (var domain in domains)
            {
                domainDictionary.Add(domain.Id, 0);
            }

            // merg prin cartile din ultimele 3 luni
            // mergi prin domeniile lor
            // daca domainDictionary contine cheia, atunci cresc valoarea la un domeniu
            // daca valoarea domeniului este > D, atunci inseamna ca are mai multe carti decat se poate si returnam fals
            // altfel, returnam true
            foreach (var book in allBooksInBorrows)
            {
                foreach (var domain in book.Domains)
                {
                    if (domainDictionary.ContainsKey(domain.Id))
                    {
                        domainDictionary[book.Id]++;

                        if (domainDictionary[book.Id] > d)
                        {
                            return false;
                        }
                    }
                    else
                    {
                        domainDictionary.Add(book.Id, 1);
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// Checks the borrowed books for maximum c books.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool CheckBorrowedBooksForMaxCBooks(Borrow entity)
        {
            var properties = this.PropertiesRepository.GetLastProperties();

            var c = this.PropertiesRepository.GetLastProperties().C;

            var castedLibrarian = (Librarian)entity.Borrower;

            if (castedLibrarian.IsReader == true)
            {
                c *= 2;
            }

            if (entity.BorrowedBooks.Count > c)
            {
                return false;
            }

            int noOfDistinctCategories = this.GetNoOfDistinctCategories(entity.BorrowedBooks.SelectMany(x => x.Domains).ToList());
            if (entity.BorrowedBooks.Count >= 3 && noOfDistinctCategories <= c)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Checks the borrow in delta time.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool CheckBorrowInDELTATime(Borrow entity)
        {
            if (entity.BorrowedBooks.Count == 1)
            {
                var properties = this.PropertiesRepository.GetLastProperties();
                var delta = this.PropertiesRepository.GetLastProperties().DELTA;
                var castedLibrarian = (Librarian)entity.Borrower;

                if (castedLibrarian.IsReader == true)
                {
                    delta /= 2;
                }

                // ultimul imprumut finalizat
                var lastBookBorrow = this.Repository.Get(
                    borrow => borrow.BorrowedBooks.Count == 1 &&
                    borrow.BorrowerId == entity.BorrowerId &&
                    borrow.BorrowedBooks.SingleOrDefault().Id == entity.BorrowedBooks.SingleOrDefault().Id &&
                    borrow.EndDate < DateTime.Now,
                    borrow => borrow.OrderBy(x => x.EndDate),
                    string.Empty).LastOrDefault();

                var deltaBookTime = DateTime.Now.AddMonths(-(int)delta);

                if (entity.BorrowDate >= deltaBookTime)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Checks the can borrow maximum NMC in per.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool CheckCanBorrowMaxNMCInPER(Borrow entity)
        {
            var properties = this.PropertiesRepository.GetLastProperties();
            var per = this.PropertiesRepository.GetLastProperties().PER;
            var nmc = this.PropertiesRepository.GetLastProperties().NMC;

            var castedLibrarian = (Librarian)entity.Borrower;

            if (castedLibrarian.IsReader == true)
            {
                per /= 2;
                nmc *= 2;
            }

            // Cartile ce au fost imprumutate in ultimele PER luni
            var datePer = DateTime.Now.AddMonths((int)-per);
            var borrowsInLastPERMonths = this.Repository.Get(borrow => borrow.BorrowDate >= datePer, borrow => borrow.OrderBy(x => x.Id), string.Empty);
            var borrowedBooksInPERPeriod = borrowsInLastPERMonths.SelectMany(borrow => borrow.BorrowedBooks).Distinct().Count();

            if (properties.NMC <= borrowedBooksInPERPeriod)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Checks the maximum borrow books today.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool CheckMaxBorrowBooksToday(Borrow entity)
        {
            var properties = this.PropertiesRepository.GetLastProperties();

            var borrowsToday = this.Repository.Get(borrow => borrow.BorrowDate == DateTime.Today, borrow => borrow.OrderBy(x => x.Id), string.Empty);

            var borrowedBooksToday = borrowsToday.SelectMany(borrow => borrow.BorrowedBooks).Distinct().Count();

            var castedLibrarian = (Librarian)entity.Borrower;

            if (castedLibrarian.IsReader == true)
            {
                return true;
            }
            else
            {
                if (properties.NCZ < borrowedBooksToday)
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Checks if books are borrowable.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool CheckIfBooksAreBorrowable(Borrow entity)
        {
            if (entity.BorrowedBooks.Count == 1)
            {
                var book = entity.BorrowedBooks.First();

                if (book.LecturesOnlyBook == true || this.CanBorrowBook(book.Title) || this.CheckLIM(entity))
                {
                    return false;
                }
            }
            else
            {
                foreach (var book in entity.BorrowedBooks)
                {
                    if (book.LecturesOnlyBook == true || this.CanBorrowBook(book.Title))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// Checks the lim.
        /// </summary>
        /// <param name="entity"> entity.</param>
        /// <returns> vrbs. </returns>
        public bool CheckLIM(Borrow entity)
        {
            // Partea cu ultimele 3 luni trebuie facuta cand se face update si se doreste sa se faca extindere
            var properties = this.PropertiesRepository.GetLastProperties();

            var book = entity.BorrowedBooks.First();

            if (entity.NoOfTimeExtended >= properties.LIM)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Gets the no of distinct categories.
        /// </summary>
        /// <param name="domains">The domains.</param>
        /// <returns>System.Int32.</returns>
        public int GetNoOfDistinctCategories(ICollection<Domain> domains)
        {
            var listOfParentDomains = new List<Domain>();

            foreach (var domain in domains)
            {
                listOfParentDomains.Add(this.GetParentDomain(domain));
            }

            listOfParentDomains = listOfParentDomains.Distinct().ToList();

            return listOfParentDomains.Count;
        }

        /// <summary>
        /// Gets the parent domain.
        /// </summary>
        /// <param name="domain">The domain.</param>
        /// <returns>Domain.</returns>
        public Domain GetParentDomain(Domain domain)
        {
            while (domain.ParentDomain != null)
            {
                domain = domain.ParentDomain;
            }

            return domain;
        }

        /// <summary>
        /// Determines whether this instance [can borrow book] the specified title.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <returns><c>true</c> if this instance [can borrow book] the specified title; otherwise, <c>false</c>.</returns>
        public bool CanBorrowBook(string title)
        {
            var allBooksWithTheSameName = this.bookRepository.GetBooksWithTheSameTitle(title);
            var unavailableBooks = this.bookRepository.GetUnavailableBooks(allBooksWithTheSameName);

            if (allBooksWithTheSameName.Count() * 0.1f < allBooksWithTheSameName.Count() - unavailableBooks.Count())
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Checks the flags.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        private bool CheckFlags(Borrow entity)
        {
            // 1. Daca cartea este doar pentru sala de lectura
            // carte poate fi imprumutata doar daca: nu are toate exemplarele marcate ca fiind doar
            // 2. O carte poate fi imprumutata doar daca: nu are toate exemplarele marcate ca fiind doar
            // pentru sala de lectura si numarul de carti ramase(inca neimprumutate, dar nu din cele
            // pentru sala de lectura) este macar 10 % din fondul initial din acea carte.
            // 3. Pot imprumuta o carte pe o perioada determinata; se permit prelungiri, dar suma
            // acestor prelungiri acordate in ultimele 3 luni nu poate depasi o valoare limita LIM data
            // Un imprumut are 2 saptamani maxim
            if (this.CheckIfBooksAreBorrowable(entity) == false)
            {
                return false;
            }

            // Pot imprumuta cel mult NCZ carti intr - o zi.
            if (this.CheckMaxBorrowBooksToday(entity) == false)
            {
                return false;
            }

            // Pot imprumuta un numar maxim de carti NMC intr-o perioada PER;
            if (this.CheckCanBorrowMaxNMCInPER(entity) == false)
            {
                return false;
            }

            // Nu pot imprumuta aceeasi carte de mai multe ori intr-un interval DELTA specificat, unde
            // DELTA se masoara de la ultimul imprumut al cartii
            if (this.CheckBorrowInDELTATime(entity) == false)
            {
                return false;
            }

            // La un imprumut pot prelua cel mult C carti; daca numarul cartilor imprumutate la o
            // cerere de imprumut e cel putin 3, atunci acestea trebui sa faca parte din cel putin 2
            // categorii distincte
            if (this.CheckBorrowedBooksForMaxCBooks(entity) == false)
            {
                return false;
            }

            // Nu pot imprumuta mai mult de D carti dintr-un acelasi domeniu – de tip frunza sau de
            // nivel superior - in ultimele L luni
            if (this.CheckIfBorrowBooksOfTheSameDomainInLastLMonths(entity) == false)
            {
                return false;
            }

            foreach (var book in entity.BorrowedBooks)
            {
                book.IsBorrowed = true;
            }

            return true;
        }
    }
}