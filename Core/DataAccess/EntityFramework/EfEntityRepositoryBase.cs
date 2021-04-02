using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity:class,IEntity,new()
        where TContext:DbContext,new()
    {
        async public Task AddAsync(TEntity entity)
        {
            using TContext context = new();
            var addedEntity = context.Entry(entity);
            addedEntity.State = EntityState.Added;
            await context.SaveChangesAsync();
            context?.DisposeAsync();
        }

        async public Task DeleteAsync(TEntity entity)
        {
            using TContext context = new();
            var deletedEntity = context.Entry(context);
            deletedEntity.State = EntityState.Deleted;
            await context.SaveChangesAsync();
            context?.DisposeAsync();
        }

        async public Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter)
        {
            using(TContext context = new())
            {
                return await context.Set<TEntity>().SingleOrDefaultAsync(filter);
            }
        }

        async public Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new())
            {
                return  filter == null ? await context.Set<TEntity>().ToListAsync()
                    : await context.Set<TEntity>().Where(filter).ToListAsync();
            }
        }

        async public Task UpdateAsync(TEntity entity)
        {
            using TContext context = new();
            var updatedEntity = context.Entry(entity);
            updatedEntity.State = EntityState.Modified;
            await context.SaveChangesAsync();
            context?.DisposeAsync();
        }
    }
}
