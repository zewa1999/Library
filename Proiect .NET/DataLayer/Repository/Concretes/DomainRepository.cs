// <copyright file="DomainRepository.cs" company="Transilvania University of Brasov">
// Costache Stelian-Andrei
// </copyright>

namespace Library.DataLayer.Concretes
{
    using Library.DataLayer.Interfaces;
    using Library.DomainLayer;

    public class DomainRepository : BaseRepository<Domain>, IDomainRepository
    {
    }
}