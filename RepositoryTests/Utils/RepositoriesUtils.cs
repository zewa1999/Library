using Library.DataLayer.Concretes;
using Library.DataLayer.Interfaces;
using Library.DomainLayer.Person;
using Library.ServiceLayer.IServices;
using Proiect_.NET.Injection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryTests
{
    public static class RepositoriesUtils
    {
        static RepositoriesUtils()
        {
            Injector.Initialize();
        }

        public static IAccountRepository GetAccountRepository()
        {
            Injector.Initialize();
            return Injector.Create<IAccountRepository>();
        }

        public static IAuthorRepository GetAuthorRepository()
        {
            Injector.Initialize();
            return Injector.Create<IAuthorRepository>();
        }

        public static IBookRepository GetBookRepository()
        {
            Injector.Initialize();
            return Injector.Create<IBookRepository>();
        }

        public static IBorrowerRepository GetBorrowerRepository()
        {
            Injector.Initialize();
            return Injector.Create<IBorrowerRepository>();
        }

        public static IBorrowRepository GetBorrowRepository()
        {
            Injector.Initialize();
            return Injector.Create<IBorrowRepository>();
        }

        public static IDomainRepository GetDomainRepository()
        {
            Injector.Initialize();
            return Injector.Create<IDomainRepository>();
        }

        public static IEditionRepository GetEditionRepository()
        {
            Injector.Initialize();
            return Injector.Create<IEditionRepository>();
        }

        public static ILibrarianRepository GetLibrarianRepository()
        {
            Injector.Initialize();
            return Injector.Create<ILibrarianRepository>();
        }

        public static IPropertiesRepository GetPropertiesRepository()
        {
            Injector.Initialize();
            return Injector.Create<IPropertiesRepository>();
        }
    }
}