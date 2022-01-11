// <copyright file="EditionService.cs" company="Transilvania University of Brasov">
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
    /// Class EditionService.
    /// Implements the <see cref="Library.ServiceLayer.Services.BaseService{Library.DomainLayer.Edition, Library.DataLayer.Interfaces.IEditionRepository}" />
    /// Implements the <see cref="Library.ServiceLayer.IServices.IEditionService" />
    /// </summary>
    /// <seealso cref="Library.ServiceLayer.Services.BaseService{Library.DomainLayer.Edition, Library.DataLayer.Interfaces.IEditionRepository}" />
    /// <seealso cref="Library.ServiceLayer.IServices.IEditionService" />
    public class EditionService : BaseService<Edition, IEditionRepository, IPropertiesRepository>, IEditionService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EditionService" /> class.
        /// </summary>
        public EditionService()
            : base(Injector.Create<IEditionRepository>(), Injector.Create<IPropertiesRepository>())
        {
            this.validator = new EditionValidator();
        }
    }
}