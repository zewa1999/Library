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

namespace Library.ServiceLayer.Services
{
    public class AuthorService : BaseService<Author>, IAuthorService
    {
        public IAuthorRepository _repo;

        public AuthorService(IAuthorRepository repo)
        {
            _repo = repo;
        }
    }
}