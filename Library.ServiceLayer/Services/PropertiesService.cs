﻿using Library.DataLayer.Interfaces;
using Library.DomainLayer;
using Library.ServiceLayer.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.ServiceLayer.Services
{
    public class PropertiesService : IPropertiesService
    {
        public IAuthorRepository _authRepo;
        public IPropertiesRepository _propRepo;

        public PropertiesService(IAuthorRepository authRepo, IPropertiesRepository propRepo)
        {
            _authRepo = authRepo;
            _propRepo = propRepo;
        }
    }
}