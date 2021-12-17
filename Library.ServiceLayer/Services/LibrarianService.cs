using Library.DataLayer.Interfaces;
using Library.DomainLayer;
using Library.DomainLayer.Person;
using Library.DomainLayer.Validators;
using Library.ServiceLayer.IServices;
using Proiect_.NET.Injection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.ServiceLayer.Services
{
    public class LibrarianService : BaseService<Librarian, ILibrarianRepository>, ILibrarianService
    {
        public LibrarianService()
            : base(Injector.Get<ILibrarianRepository>(), new LibrarianValidator())
        {
        }
    }
}