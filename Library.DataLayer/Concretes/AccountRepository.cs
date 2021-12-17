using Library.DataLayer.Interfaces;
using Library.DomainLayer;
using Library.DomainLayer.Person;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DataLayer.Concretes
{
    public class AccountRepository : BaseRepository<Account>, IAccountRepository
    {
    }
}