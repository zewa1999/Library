// <copyright file="BorrowerService.cs" company="Transilvania University of Brasov">
// Costache Stelian-Andrei
// </copyright>

namespace Library.ServiceLayer.Services
{
    using Library.DataLayer.Interfaces;
    using Library.DataLayer.Validators;
    using Library.DomainLayer.Person;
    using Library.ServiceLayer.IServices;
    using Proiect_.NET.Injection;

    /// <summary>
    /// Class BorrowerService.
    /// Implements the <see cref="Library.ServiceLayer.Services.BaseService{Library.DomainLayer.Person.Borrower, Library.DataLayer.Interfaces.IBorrowerRepository}" />
    /// Implements the <see cref="Library.ServiceLayer.IServices.IBorrowerService" />.
    /// </summary>
    /// <seealso cref="Library.ServiceLayer.Services.BaseService{Library.DomainLayer.Person.Borrower, Library.DataLayer.Interfaces.IBorrowerRepository}" />
    /// <seealso cref="Library.ServiceLayer.IServices.IBorrowerService" />
    public class BorrowerService : BaseService<Borrower, IBorrowerRepository, IPropertiesRepository>, IBorrowerService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BorrowerService" /> class.
        /// </summary>
        public BorrowerService()
            : base(Injector.Create<IBorrowerRepository>(), Injector.Create<IPropertiesRepository>())
        {
            this.Validator = new BorrowerValidator();
        }
    }
}