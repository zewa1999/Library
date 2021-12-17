using Library.DataLayer.Concretes;
using Library.DomainLayer;
using Library.DataLayer;
using Library.ServiceLayer.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.DataLayer.Interfaces;
using Library.DomainLayer.Validators;
using Proiect_.NET.Injection;

namespace Library.ServiceLayer.Services
{
    public class AuthorService : BaseService<Author, IAuthorRepository>, IAuthorService
    {
        public AuthorService()
            : base(Injector.Get<IAuthorRepository>(), new AuthorValidator())
        {
        }
    }
}