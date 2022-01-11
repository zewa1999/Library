// <copyright file="Bindings.cs" company="Transilvania University of Brasov">
// Costache Stelian-Andrei
// </copyright>

namespace Proiect_.NET.Injection
{
    using Library.DataLayer.Concretes;
    using Library.DataLayer.Interfaces;
    using Library.ServiceLayer.IServices;
    using Library.ServiceLayer.Services;
    using Ninject.Modules;

    /// <summary>
    /// Class Bindings.
    /// Implements the <see cref="Ninject.Modules.NinjectModule" />.
    /// </summary>
    /// <seealso cref="Ninject.Modules.NinjectModule" />
    public class Bindings : NinjectModule
    {
        /// <summary>
        /// Loads the module into the kernel.
        /// </summary>
        public override void Load()
        {
            this.LoadRepositoryLayer();
            this.LoadServicesLayer();
        }

        /// <summary>
        /// Loads the services layer.
        /// </summary>
        private void LoadServicesLayer()
        {
            this.Bind<IAuthorService>().To<AuthorService>();
            this.Bind<IBookService>().To<BookService>();
            this.Bind<IBorrowerService>().To<BorrowerService>();
            this.Bind<IBorrowService>().To<BorrowService>();
            this.Bind<IDomainService>().To<DomainService>();
            this.Bind<IEditionService>().To<EditionService>();
            this.Bind<ILibrarianService>().To<LibrarianService>();
            this.Bind<IPropertiesService>().To<PropertiesService>();
            this.Bind<IAccountService>().To<AccountService>();
        }

        /// <summary>
        /// Loads the repository layer.
        /// </summary>
        private void LoadRepositoryLayer()
        {
            this.Bind<IAuthorRepository>().To<AuthorRepository>();
            this.Bind<IBookRepository>().To<BookRepository>();
            this.Bind<IBorrowerRepository>().To<BorrowerRepository>();
            this.Bind<IBorrowRepository>().To<BorrowRepository>();
            this.Bind<IDomainRepository>().To<DomainRepository>();
            this.Bind<IEditionRepository>().To<EditionRepository>();
            this.Bind<ILibrarianRepository>().To<LibrarianRepository>();
            this.Bind<IPropertiesRepository>().To<PropertiesRepository>();
            this.Bind<IAccountRepository>().To<AccountRepository>();
        }
    }
}