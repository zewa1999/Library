using Library.DataLayer.Concretes;
using Library.DataLayer.DataMapper;
using Library.DomainLayer.Person;
using Library.ServiceLayer.IServices;
using Library.ServiceLayer.Services;
using Proiect_.NET.Injection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect_.NET
{
    public class UI
    {
        public static void Main(String[] args)
        {
            //var repo = new AccountRepository();
            //repo.Insert(new()
            //{
            //    PhoneNumber = "0734525427",
            //    Email = "validemail@gmail.com"
            //});
            Injector.Initialize();
            //var account = new Account()
            //{
            //    PhoneNumber = "0734525427",
            //    Email = "validemail@gmail.com"
            //};

            //var borrower = new Borrower()
            //{
            //    LastName = "Marcel",
            //    FirstName = "Gigel",
            //    Address = "Haidee",
            //    Account = account
            //};

            var borrowerService = Injector.Create<IBorrowerService>();
            //borrowerService.Insert(borrower);
            var borrower = borrowerService.GetByID(1);
            var email = borrower.Account.Email;
            Console.WriteLine(email);
        }
    }
}