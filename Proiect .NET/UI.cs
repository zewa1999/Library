using Library.DataLayer.Concretes;
using Library.DataLayer.DataMapper;
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
            var service = new AccountService();
            service.Insert(new()
            {
                PhoneNumber = "0734525427",
                Email = "validemail@gmail.com"
            });
        }
    }
}