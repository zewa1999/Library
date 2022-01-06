// ***********************************************************************
// Assembly         : Library
// Author           : costa
// Created          : 01-06-2022
//
// Last Modified By : costa
// Last Modified On : 01-06-2022
// ***********************************************************************
// <copyright file="Bindings.cs" company="Library">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Library.DataLayer.Concretes;
using Library.DataLayer.Interfaces;
using Library.ServiceLayer.IServices;
using Library.ServiceLayer.Services;
using Ninject.Modules;

namespace Proiect_.NET.Injection
{
    /// <summary>
    /// Class Bindings.
    /// Implements the <see cref="Ninject.Modules.NinjectModule" />
    /// </summary>
    /// <seealso cref="Ninject.Modules.NinjectModule" />
    public class Bindings : NinjectModule
    {
        /// <summary>
        /// Loads the module into the kernel.
        /// </summary>
        public override void Load()
        {
            LoadRepositoryLayer();
            LoadServicesLayer();
        }

        /// <summary>
        /// Loads the services layer.
        /// </summary>
        private void LoadServicesLayer()
        {
            Bind<IAuthorService>().To<AuthorService>();
            Bind<IBookService>().To<BookService>();
            Bind<IBorrowerService>().To<BorrowerService>();
            Bind<IBorrowService>().To<BorrowService>();
            Bind<IDomainService>().To<DomainService>();
            Bind<IEditionService>().To<EditionService>();
            Bind<ILibrarianService>().To<LibrarianService>();
            Bind<IPropertiesService>().To<PropertiesService>();
            Bind<IAccountService>().To<AccountService>();
        }

        /// <summary>
        /// Loads the repository layer.
        /// </summary>
        private void LoadRepositoryLayer()
        {
            Bind<IAuthorRepository>().To<AuthorRepository>();
            Bind<IBookRepository>().To<BookRepository>();
            Bind<IBorrowerRepository>().To<BorrowerRepository>();
            Bind<IBorrowRepository>().To<BorrowRepository>();
            Bind<IDomainRepository>().To<DomainRepository>();
            Bind<IEditionRepository>().To<EditionRepository>();
            Bind<ILibrarianRepository>().To<LibrarianRepository>();
            Bind<IPropertiesRepository>().To<PropertiesRepository>();
            Bind<IAccountRepository>().To<AccountRepository>();
        }
    }
}