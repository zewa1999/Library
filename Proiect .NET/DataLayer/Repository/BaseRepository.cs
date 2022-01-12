// <copyright file="BaseRepository.cs" company="Transilvania University of Brasov">
// Costache Stelian-Andrei
// </copyright>

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
        /// Gets or sets the CTX.
        /// </summary>
        /// <value>The CTX.</value>
        protected LibraryContext Ctx { get; set; } = new LibraryContext();

        /// <summary>
        /// Gets or sets the logger.
        /// </summary>
        /// <value>The logger.</value>
        protected Logger Logger { get; set; } = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Gets the specified filter.
        /// </summary>
        /// <param name="filter"> The filter. </param>
        /// <param name="orderBy"> The order by. </param>
        /// <param name="includeProperties"> The include properties. </param>
        /// <returns> ceva. </returns>
        public virtual IEnumerable<T> Get(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "")
        {
            try
            {
                var databaseSet = this.Ctx.Set<T>();

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
                this.Logger.Error(ex.Message + "The query will return an empty list!");
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
                var databaseSet = this.Ctx.Set<T>();
                databaseSet.Add(entity);
                this.Ctx.SaveChanges();

                entity = null;
            }
            catch (Exception ex)
            {
                this.Logger.Error(ex.Message + ex.InnerException + "The INSERT could not been made!");
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
                var databaseSet = this.Ctx.Set<T>();
                databaseSet.Attach(item);
                this.Ctx.Entry(item).State = EntityState.Modified;

                this.Ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                this.Logger.Error(ex.Message + ex.InnerException + "The UPDATE could not been made!");
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
                this.Logger.Error(ex.Message + ex.InnerException + "The DELETE could not been made!");
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
                var dbSet = this.Ctx.Set<T>();

                if (this.Ctx.Entry(entityToDelete).State == EntityState.Detached)
                {
                    dbSet.Attach(entityToDelete);
                }

                dbSet.Remove(entityToDelete);

                this.Ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                this.Logger.Error(ex.Message + ex.InnerException + "The DELETE could not been made!");
                return false;
            }

            return true;
        }

        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="id"> The identifier. </param>
        /// <returns> ceva. </returns>
        public virtual T GetByID(object id)
        {
            try
            {
                return this.Ctx.Set<T>().Find(id);
            }
            catch (Exception ex)
            {
                this.Logger.Error(ex.Message + ex.InnerException + "The GetByID could not been made. Will return null!");
            }

            return null;
        }

        /// <summary>
        /// Deletes all entities from table.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool DeleteAllEntitiesFromTable()
        {
            try
            {
                var dbSet = this.Ctx.Set<T>();
                dbSet.RemoveRange(dbSet);
                this.Ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                this.Logger.Error(ex.Message + ex.InnerException + "The DeleteAllEntitiesFromTable could not been made.");
                return false;
            }

            return true;
        }
    }
}