// ***********************************************************************
// Assembly         : Library.ServiceLayer
// Author           : costa
// Created          : 12-17-2021
//
// Last Modified By : costa
// Last Modified On : 12-18-2021
// ***********************************************************************
// <copyright file="BookService.cs" company="Library.ServiceLayer">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Library.DataLayer.Interfaces;
using Library.DataLayer.Validators;
using Library.DomainLayer;
using Library.ServiceLayer.IServices;
using Proiect_.NET.Injection;

namespace Library.ServiceLayer.Services
{
    /// <summary>
    /// Class BookService.
    /// Implements the <see cref="Library.ServiceLayer.Services.BaseService{Library.DomainLayer.Book, Library.DataLayer.Interfaces.IBookRepository}" />
    /// Implements the <see cref="Library.ServiceLayer.IServices.IBookService" />
    /// </summary>
    /// <seealso cref="Library.ServiceLayer.Services.BaseService{Library.DomainLayer.Book, Library.DataLayer.Interfaces.IBookRepository}" />
    /// <seealso cref="Library.ServiceLayer.IServices.IBookService" />
    public class BookService : BaseService<Book, IBookRepository, IPropertiesRepository>, IBookService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BookService"/> class.
        /// </summary>
        /// <param name="bookRepository">The book repository.</param>
        /// <param name="propertiesRepository">The properties repository.</param>
        public BookService()
            : base(Injector.Create<IBookRepository>(), Injector.Create<IPropertiesRepository>())
        {
            _validator = new BookValidator(_propertiesRepository);
        }
    }
}