using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using AnteaNL.CustomerSatisfaction.Common.Exceptions;
using BuildingVitals.DataAccessContracts.Entities.Base;
using BuildingVitals.DataAccessContracts.Repositories.Base;
using BuildingVitals.DataAccessImplementations.Context;
using Microsoft.EntityFrameworkCore;

namespace BuildingVitals.DataAccessImplementations.Repositories.Base
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class, IEntity
    {
        protected readonly AppDbContext Context;

        protected BaseRepository(AppDbContext context)
        {
            Context = context;
        }

        public virtual T GetById(Guid id)
        {
            return Context.Set<T>().Find(id);
        }

        public virtual List<T> GetAll()
        {
            return Context.Set<T>().ToList();
        }

        public T Insert(T entity)
        {
            return TryToExecute(() =>
            {
                entity.Id = Guid.NewGuid();
                var savedEntiy = Context.Add(entity);

                return savedEntiy.Entity;
            });
        }

        public void Update(T entity)
        {
            TryToExecute(() =>
            {
                Context.Entry(entity).State = EntityState.Modified;
                return entity;
            });
        }

        public void Delete(T entity)
        {
            TryToExecute(() => Context.Remove(entity));
        }

        public List<T> Filter(Expression<Func<T, bool>> predicate, IEnumerable<Expression<Func<T, object>>> includeProperties = null)
        {
            var entities = Context.Set<T>().Where(predicate);

            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties)
                {
                    entities = entities.Include(includeProperty);
                }
            }

            return entities.ToList();
        }

        public void Save()
        {
            TryToExecute(() => Context.SaveChanges());
        }

        public void Dispose()
        {
            Context.Dispose();
        }

        protected TResult TryToExecute<TResult>(Func<TResult> function)
        {
            try
            {
                return function();
            }
            catch (DbUpdateException e)
            {
                throw new BadRequestException(ExceptionMessages.BadRequest, e);
            }
            catch (SqlException e)
            {
                if (IsSqlConnectionOpened(e))
                {
                    throw new BadRequestException(ExceptionMessages.BadRequest, e);
                }

                throw;
            }
        }

        private bool IsSqlConnectionOpened(SqlException e)
        {
            return e.Class < 20;
        }
    }
}
