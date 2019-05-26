using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BuildingVitals.DataAccessContracts.Entities.Base;

namespace BuildingVitals.DataAccessContracts.Repositories.Base
{
    /// <summary>
    /// The base interface for each repository.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IBaseRepository<T> where T : IEntity
    {
        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        T GetById(Guid id);

        /// <summary>
        /// Gets all as list.
        /// </summary>
        /// <returns></returns>
        List<T> GetAll();

        /// <summary>
        /// Inserts the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        T Insert(T entity);

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Delete(T entity);

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Update(T entity);

        /// <summary>
        /// Saves the modifications.
        /// </summary>
        void Save();

        /// <summary>
        /// Filters by the specified predicate and includes the given properties.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns></returns>
        List<T> Filter(Expression<Func<T, bool>> predicate, IEnumerable<string> includeProperties = null);
    }
}
