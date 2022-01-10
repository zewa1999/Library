// ***********************************************************************
// Assembly         : Library
// Author           : costa
// Created          : 01-06-2022
//
// Last Modified By : costa
// Last Modified On : 01-06-2022
// ***********************************************************************
// <copyright file="DomainRepository.cs" company="Library">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
/// <summary>
/// The Concretes namespace.
/// </summary>
namespace Library.DataLayer.Concretes
{
    using Library.DataLayer.DataMapper;
    using Library.DataLayer.Interfaces;
    using Library.DomainLayer;
    using Library.DomainLayer.Person;

    /// <summary>
    /// Methods for the domain controller.
    /// </summary>
    public class DomainRepository : BaseRepository<Domain>, IDomainRepository
    {
        public override Domain GetByID(object id)
        {
            using (var ctx = new LibraryContext())
            {
                var entity = ctx.Domains.Find(id);
                ctx.Entry(entity).Reference(p => p.ParentDomain).Load();
                ctx.Entry(entity).Collection(p => p.ChildrenDomains).Load();

                return entity;
            }
        }
    }
}