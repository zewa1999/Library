// ***********************************************************************
// Assembly         : Library
// Author           : costa
// Created          : 01-06-2022
//
// Last Modified By : costa
// Last Modified On : 01-06-2022
// ***********************************************************************
// <copyright file="LibrarianRepository.cs" company="Library">
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
    using Library.DomainLayer.Person;

    /// <summary>
    /// Methods for the librarian controller.
    /// </summary>
    public class LibrarianRepository : BaseRepository<Librarian>, ILibrarianRepository
    {
        public override Librarian GetByID(object id)
        {
            using (var ctx = new LibraryContext())
            {
                var entity = ctx.Librarians.Find(id);
                ctx.Entry(entity).Reference(p => p.Account).Load();
                return entity;
            }
        }
    }
}