using Library.DataLayer.Concretes;
using Library.DataLayer.Interfaces;
using Library.ServiceLayer.IServices;
using Library.ServiceLayer.Services;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect_.NET.Injection
{
    public class Bindings : NinjectModule
    {
        public override void Load()
        {
            LoadRepositoryLayer();
            LoadServicesLayer();
        }

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