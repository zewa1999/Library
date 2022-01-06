// ***********************************************************************
// Assembly         : Library.ServiceLayer
// Author           : costa
// Created          : 12-17-2021
//
// Last Modified By : costa
// Last Modified On : 12-18-2021
// ***********************************************************************
// <copyright file="AuthorService.cs" company="Library.ServiceLayer">
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
    /// Class AuthorService.
    /// Implements the <see cref="Library.ServiceLayer.Services.BaseService{Library.DomainLayer.Author, Library.DataLayer.Interfaces.IAuthorRepository}" />
    /// Implements the <see cref="Library.ServiceLayer.IServices.IAuthorService" />
    /// </summary>
    /// <seealso cref="Library.ServiceLayer.Services.BaseService{Library.DomainLayer.Author, Library.DataLayer.Interfaces.IAuthorRepository}" />
    /// <seealso cref="Library.ServiceLayer.IServices.IAuthorService" />
    public class AuthorService : BaseService<Author, IAuthorRepository, IPropertiesRepository>, IAuthorService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AuthorService"/> class.
        /// </summary>
        /// <param name="authorRepository">The author repository.</param>
        /// <param name="propertiesRepository">The properties repository.</param>
        public AuthorService()
            : base(Injector.Create<IAuthorRepository>(), Injector.Create<IPropertiesRepository>())
        {
            _validator = new AuthorValidator();
        }
    }
}