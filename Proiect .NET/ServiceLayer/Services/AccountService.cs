// <copyright file="AccountService.cs" company="Transilvania University of Brasov">
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
    /// Class AccountService.
    /// Implements the <see cref="Library.ServiceLayer.Services.BaseService{Library.DomainLayer.Person.Account, Library.DataLayer.Interfaces.IAccountRepository}" />
    /// Implements the <see cref="Library.ServiceLayer.IServices.IAccountService" />
    /// </summary>
    /// <seealso cref="Library.ServiceLayer.Services.BaseService{Library.DomainLayer.Person.Account, Library.DataLayer.Interfaces.IAccountRepository}" />
    /// <seealso cref="Library.ServiceLayer.IServices.IAccountService" />
    public class AccountService : BaseService<Account, IAccountRepository, IPropertiesRepository>, IAccountService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AccountService" /> class.
        /// </summary>
        public AccountService()
            : base(Injector.Create<IAccountRepository>(), Injector.Create<IPropertiesRepository>())
        {
            this.validator = new AccountValidator();
        }
    }
}