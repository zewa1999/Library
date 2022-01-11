// <copyright file="LibrarianService.cs" company="Transilvania University of Brasov">
// Costache Stelian-Andrei
// </copyright>

namespace Library.ServiceLayer.Services
{
    using Library.DataLayer.Interfaces;
    using Library.DataLayer.Validators;
    using Library.DomainLayer.Person;
    using Library.ServiceLayer.IServices;
    using Proiect_.NET.Injection;

    /// <summary>
    /// Class LibrarianService.
    /// Implements the <see cref="Library.ServiceLayer.Services.BaseService{Library.DomainLayer.Person.Librarian, Library.DataLayer.Interfaces.ILibrarianRepository}" />
    /// Implements the <see cref="Library.ServiceLayer.IServices.ILibrarianService" />
    /// </summary>
    /// <seealso cref="Library.ServiceLayer.Services.BaseService{Library.DomainLayer.Person.Librarian, Library.DataLayer.Interfaces.ILibrarianRepository}" />
    /// <seealso cref="Library.ServiceLayer.IServices.ILibrarianService" />
    public class LibrarianService : BaseService<Librarian, ILibrarianRepository, IPropertiesRepository>, ILibrarianService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LibrarianService" /> class.
        /// </summary>
        public LibrarianService()
            : base(Injector.Create<ILibrarianRepository>(), Injector.Create<IPropertiesRepository>())
        {
            this.validator = new LibrarianValidator();
        }
    }
}