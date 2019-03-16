using System;
using System.Collections.Generic;
using BuildingVitals.BusinessContracts.Models.Base;

namespace BuildingVitals.BusinessContracts.Services.Base
{
    /// <summary>
    /// The base service that expose all the CRUD operations.
    /// </summary>
    /// <typeparam name="TModel">The type of the dto.</typeparam>
    public interface IBaseService<TModel>
        where TModel : BaseModel
    {
        /// <summary>
        /// Gets all the entities of TEntity type as a list of TDto objects.
        /// </summary>
        /// <returns>List of TDto objects</returns>
        List<TModel> GetAll();

        /// <summary>
        /// Gets the entity by Id mapped as a TDto object.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>TDto object</returns>
        TModel GetById(Guid id);

        /// <summary>
        /// Adds the specified entity.
        /// </summary>
        /// <param name="model">The entity dto.</param>
        /// <returns>The inserted Guid for the entity</returns>
        Guid Add(TModel model);


        /// <summary>
        /// Finds the entity by her identifier and delete it.
        /// </summary>
        /// <param name="entityId">The entity identifier.</param>
        void Delete(Guid entityId);

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="model">The entity dto.</param>
        void Update(TModel model);
    }
}
