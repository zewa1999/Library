// ***********************************************************************
// Assembly         : Library.ServiceLayer
// Author           : costa
// Created          : 12-17-2021
//
// Last Modified By : costa
// Last Modified On : 12-18-2021
// ***********************************************************************
// <copyright file="LibrarianService.cs" company="Library.ServiceLayer">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Library.DataLayer.Interfaces;
using Library.DataLayer.Validators;
using Library.DomainLayer.Person;
using Library.ServiceLayer.IServices;
using Proiect_.NET.Injection;

namespace Library.ServiceLayer.Services
{
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
        /// Initializes a new instance of the <see cref="LibrarianService"/> class.
        /// </summary>
        /// <param name="librarianRepository">The librarian repository.</param>
        /// <param name="propertiesRepository">The properties repository.</param>
        public LibrarianService()
            : base(Injector.Create<ILibrarianRepository>(), Injector.Create<IPropertiesRepository>())
        {
            _validator = new LibrarianValidator(_propertiesRepository);
        }
    }
}