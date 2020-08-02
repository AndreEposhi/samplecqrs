using SampleCqrs.Domain.Interfaces.Repositories;
using SampleCqrs.Domain.Models;
using SampleCqrs.Infra.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;

namespace SampleCqrs.Infra.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity>
        where TEntity : ModelBase
    {
        private readonly SampleCqrsDbContext context;

        public Repository(SampleCqrsDbContext context)
        {
            this.context = context;
        }

        public void Add(TEntity entity) => context.Set<TEntity>().Add(entity);

        public void Remove(Guid id)
        {
            var entity = GetById(id);

            if (entity != null)
                context.Set<TEntity>().Remove(entity);
        }

        public IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> predicate) => context.Set<TEntity>().Where(predicate).ToList();

        public IEnumerable<TEntity> GetAll() => context.Set<TEntity>().ToList();

        public TEntity GetById(Guid id) => context.Set<TEntity>().Find(id);

        public void Update(TEntity entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            context.Set<TEntity>().AddOrUpdate(entity);
        }
    }
}