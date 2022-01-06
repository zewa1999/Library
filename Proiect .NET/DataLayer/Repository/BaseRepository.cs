// ***********************************************************************
// Assembly         : Library
// Author           : costa
// Created          : 01-06-2022
//
// Last Modified By : costa
// Last Modified On : 01-06-2022
// ***********************************************************************
// <copyright file="BaseRepository.cs" company="Library">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
/// <summary>
/// The DataLayer namespace.
/// </summary>
namespace Library.DataLayer
{
    using Library.DataLayer.DataMapper;
    using Library.DataLayer.Interfaces;
    using Microsoft.EntityFrameworkCore;
    using NLog;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    /// <summary>
    /// Abstract class to be inherited to implement the CRUD operation for an entity.
    /// </summary>
    /// <typeparam name="T">Type of the controller.</typeparam>
    public abstract class BaseRepository<T> : IRepository<T>
        where T : class
    {
        /// <summary>
        /// The logger
        /// </summary>
        protected readonly Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Gets the specified filter.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>IEnumerable&lt;T&gt;.</returns>
        public virtual IEnumerable<T> Get(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "")
        {
            using (var ctx = new LibraryContext())
            {
                try
                {
                    var dbSet = ctx.Set<T>();

                    IQueryable<T> query = dbSet;

                    if (filter != null)
                    {
                        query = query.Where(filter);
                    }

                    foreach (var includeProperty in includeProperties.Split
                        (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                    {
                        query = query.Include(includeProperty);
                    }

                    if (orderBy != null)
                    {
                        return orderBy(query).ToList();
                    }
                    else
                    {
                        return query.ToList();
                    }
                }
                catch (Exception ex)
                {
                    logger.Error(ex.Message + "The query will return an empty list!");
                }
            }
            return new List<T>();
        }

        /// <summary>
        /// Inserts the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public virtual void Insert(T entity)
        {
            using (var ctx = new LibraryContext())
            {
                try
                {
                    var dbSet = ctx.Set<T>();
                    dbSet.Add(entity);
                    ctx.SaveChanges();
                }
                catch (Exception ex)
                {
                    logger.Error(ex.Message + "The INSERT could not been made!");
                }
            }
        }

        /// <summary>
        /// Updates the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        public virtual void Update(T item)
        {
            using (var ctx = new LibraryContext())
            {
                try
                {
                    var dbSet = ctx.Set<T>();
                    dbSet.Attach(item);
                    ctx.Entry(item).State = EntityState.Modified;

                    ctx.SaveChanges();
                }
                catch (Exception ex)
                {
                    logger.Error(ex.Message + "The UPDATE could not been made!");
                }
            }
        }

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public virtual void Delete(object id)
        {
            Delete(GetByID(id));
        }

        /// <summary>
        /// Deletes the specified entity to delete.
        /// </summary>
        /// <param name="entityToDelete">The entity to delete.</param>
        public virtual void Delete(T entityToDelete)
        {
            using (var ctx = new LibraryContext())
            {
                try
                {
                    var dbSet = ctx.Set<T>();

                    if (ctx.Entry(entityToDelete).State == EntityState.Detached)
                    {
                        dbSet.Attach(entityToDelete);
                    }

                    dbSet.Remove(entityToDelete);

                    ctx.SaveChanges();
                }
                catch (Exception ex)
                {
                    logger.Error(ex.Message + "The DELETE could not been made!");
                }
            }
        }

        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>T.</returns>
        public virtual T GetByID(object id)
        {
            using (var ctx = new LibraryContext())
            {
                try
                {
                    return ctx.Set<T>().Find(id);
                }
                catch (Exception ex)
                {
                    logger.Error(ex.Message + "The GetByID could not been made. Will return null!");
                }
                return null;
            }
        }
    }
}