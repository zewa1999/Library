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
    public class AccountService : BaseService<Account, IAccountRepository>, IAccountService
    {
        public AccountService()
            : base(Injector.Get<IAccountRepository>(), new AccountValidator())
        {
        }
    }
}