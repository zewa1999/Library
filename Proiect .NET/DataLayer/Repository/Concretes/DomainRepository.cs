// ***********************************************************************
// Assembly         : Library
// Author           : costa
// Created          : 01-06-2022
//
// Last Modified By : costa
// Last Modified On : 01-06-2022
// ***********************************************************************
// <copyright file="DomainRepository.cs" company="Transilvania University of Brasov">
//     Costache Stelian-Andrei
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace Library.DataLayer.Concretes
{
    using Library.DataLayer.DataMapper;
    using Library.DataLayer.Interfaces;
    using Library.DomainLayer;
    using Library.DomainLayer.Person;

    public class DomainRepository : BaseRepository<Domain>, IDomainRepository
    {
    }
}