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
    public class BorrowService : BaseService<Borrow, IBorrowRepository>, IBorrowService
    {
        public BorrowService()
             : base(Injector.Get<IBorrowRepository>(), new BorrowValidator())
        {
        }
    }
}