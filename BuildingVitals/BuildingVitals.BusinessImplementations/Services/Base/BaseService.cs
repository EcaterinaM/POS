using System;
using System.Collections.Generic;
using AutoMapper;
using BuildingVitals.BusinessContracts.Models.Base;
using BuildingVitals.BusinessContracts.Services.Base;
using BuildingVitals.DataAccessContracts.Entities.Base;
using BuildingVitals.DataAccessContracts.Repositories.Base;

namespace BuildingVitals.BusinessImplementations.Services.Base
{
    public class BaseService<TRepository, TEntity, TModel> : IBaseService<TModel>
        where TRepository : IBaseRepository<TEntity>
        where TEntity : class, IEntity
        where TModel : BaseModel
    {
        protected TRepository Repository;
        protected readonly IMapper ServiceMapper;

        public BaseService(TRepository repository, IMapper serviceMapper)
        {
            Repository = repository;
            ServiceMapper = serviceMapper;
        }

        public List<TModel> GetAll()
        {
            var entities = Repository.GetAll();
            return ServiceMapper.Map<List<TModel>>(entities);
        }

        public TModel GetById(Guid id)
        {
            try
            {
                var entity = Repository.GetById(id);
                return ServiceMapper.Map<TModel>(entity);
            }
            catch
            {
                return null;
            }
        }

        public virtual Guid Add(TModel model)
        {
            var entity = ServiceMapper.Map<TEntity>(model);
            var insertedGuid = (Repository.Insert(entity)).Id;
            Repository.Save();

            return insertedGuid;
        }

        public virtual void Delete(Guid entityId)
        {
            var entity = Repository.GetById(entityId);
            if (entity != null)
            {
                Repository.Delete(entity);
                Repository.Save();
            }
        }

        public void Update(TModel model)
        {
            var entity = ServiceMapper.Map<TEntity>(model);
            Repository.Update(entity);
            Repository.Save();
        }
    }
}
