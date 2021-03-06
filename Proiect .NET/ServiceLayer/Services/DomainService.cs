// <copyright file="DomainService.cs" company="Transilvania University of Brasov">
// Costache Stelian-Andrei
// </copyright>

namespace Library.ServiceLayer.Services
{
    using Library.DataLayer.Interfaces;
    using Library.DataLayer.Validators;
    using Library.DomainLayer;
    using Library.ServiceLayer.IServices;
    using Proiect_.NET.Injection;

    /// <summary>
    /// Class DomainService.
    /// Implements the <see cref="Library.ServiceLayer.Services.BaseService{Library.DomainLayer.Domain, Library.DataLayer.Interfaces.IDomainRepository}" />
    /// Implements the <see cref="Library.ServiceLayer.IServices.IDomainService" />.
    /// </summary>
    /// <seealso cref="Library.ServiceLayer.Services.BaseService{Library.DomainLayer.Domain, Library.DataLayer.Interfaces.IDomainRepository}" />
    /// <seealso cref="Library.ServiceLayer.IServices.IDomainService" />
    public class DomainService : BaseService<Domain, IDomainRepository, IPropertiesRepository>, IDomainService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DomainService" /> class.
        /// </summary>
        public DomainService()
             : base(Injector.Create<IDomainRepository>(), Injector.Create<IPropertiesRepository>())
        {
            this.Validator = new DomainValidator();
        }

        /// <inheritdoc/>
        public override bool Insert(Domain entity)
        {
            if (entity.ParentDomain == null)
            {
                this.Validator = new BaseDomainValidator();
            }

            var result = this.Validator.Validate(entity);
            var isValid = false;
            if (result.IsValid)
            {
                isValid = true;
            }
            else
            {
                Utils.LogErrors(result);
                return false;
            }

            if (isValid == true)
            {
                this.Repository.Insert(entity);
            }

            this.Validator = new DomainValidator();
            return true;
        }
    }
}