using SampleCqrs.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SampleCqrs.Domain.Interfaces.Repositories
{
    public interface IRepository<TEntity> where TEntity : ModelBase
    {
        void Add(TEntity entity);

        void Remove(Guid id);

        void Update(TEntity entity);

        TEntity GetById(Guid id);

        IEnumerable<TEntity> GetAll();

        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> predicate);
    }
}