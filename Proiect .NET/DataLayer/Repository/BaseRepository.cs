// ***********************************************************************
// Assembly         : Library
// Author           : costa
// Created          : 01-06-2022
//
// Last Modified By : costa
// Last Modified On : 01-09-2022
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
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using Library.DataLayer.DataMapper;
    using Library.DataLayer.Interfaces;
    using Microsoft.EntityFrameworkCore;
    using NLog;

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

        protected readonly LibraryContext ctx = new LibraryContext();

        /// <summary>
        /// Gets the specified filter.
        /// </summary>
        /// <param name="filter"> The filter. </param>
        /// <param name="orderBy"> The order by. </param>
        /// <param name="includeProperties"> The include properties. </param>
        public virtual IEnumerable<T> Get(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "")
        {
            try
            {
                var databaseSet = ctx.Set<T>();

                IQueryable<T> query = databaseSet;

                if (filter != null)
                {
                    query = query.Where(filter);
                }

                foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
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
                this.logger.Error(ex.Message + "The query will return an empty list!");
            }

            return null;
        }

        /// <summary>
        /// Inserts the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public virtual bool Insert(T entity)
        {
            try
            {
                var databaseSet = ctx.Set<T>();
                databaseSet.Add(entity);
                ctx.SaveChanges();

                entity = null;
            }
            catch (Exception ex)
            {
                this.logger.Error(ex.Message + ex.InnerException + "The INSERT could not been made!");
                return false;
            }

            return true;
        }

        /// <summary>
        /// Updates the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public virtual bool Update(T item)
        {
            try
            {
                var databaseSet = ctx.Set<T>();
                databaseSet.Attach(item);
                ctx.Entry(item).State = EntityState.Modified;

                ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                this.logger.Error(ex.Message + ex.InnerException + "The UPDATE could not been made!");
                return false;
            }

            return true;
        }

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public virtual bool DeleteById(object id)
        {
            try
            {
                this.Delete(this.GetByID(id));
            }
            catch (Exception ex)
            {
                this.logger.Error(ex.Message + ex.InnerException + "The DELETE could not been made!");
                return false;
            }

            return true;
        }

        /// <summary>
        /// Deletes the specified entity to delete.
        /// </summary>
        /// <param name="entityToDelete">The entity to delete.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public virtual bool Delete(T entityToDelete)
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
                this.logger.Error(ex.Message + ex.InnerException + "The DELETE could not been made!");
                return false;
            }

            return true;
        }

        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="id"> The identifier. </param>
        public virtual T GetByID(object id)
        {
            try
            {
                return ctx.Set<T>().Find(id);
            }
            catch (Exception ex)
            {
                this.logger.Error(ex.Message + ex.InnerException + "The GetByID could not been made. Will return null!");
            }

            return null;
        }
    }
}