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
    public class AuthorService : IAuthorService
    {
        public IAuthorRepository _authRepo;
        public IPropertiesRepository _propRepo;

        public AuthorService(IAuthorRepository authRepo, IPropertiesRepository propRepo)
        {
            _authRepo = authRepo;
            _propRepo = propRepo;
        }
    }
}