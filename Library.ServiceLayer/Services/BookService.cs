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
    public class BookService : BaseService<Book, IBookRepository>, IBookService
    {
        public BookService()
            : base(Injector.Get<IBookRepository>(), new BookValidator())
        {
        }
    }
}