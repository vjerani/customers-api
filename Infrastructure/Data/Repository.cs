using Core.Entities;
using Core.Exceptions;
using Core.Interfaces;
using Infrastructure.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class Repository<T> : IRepository<T> where T : BaseEntity, IAggregateRoot
    {
        private readonly CustomersContext _dbcontext;
        private readonly DbSet<T> entities;

        public Repository(CustomersContext dbcontext)
        {
            _dbcontext = dbcontext;
            entities = _dbcontext.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return entities.ToList();
        }

        public async Task<IEnumerable<T>> GetAllAsync(CancellationToken token = default)
        {
            return await entities.ToListAsync(token);
        }

        public T GetById(int id)
        {
            var entity = entities.SingleOrDefault(x => x.Id == id);
            if (entity == null)
            {
                throw new EntityNotFoundException(id, typeof(T));
            }
            return entity;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var entity = await entities.SingleOrDefaultAsync(x => x.Id == id);
            if (entity == null)
            {
                throw new EntityNotFoundException(id, typeof(T));
            }
            return entity;
        }

        public void Insert(T entity)
        {
            entities.Add(entity);
        }

        public int InsertAndGetId(T entity)
        {
            Insert(entity);
            _dbcontext.SaveChanges();
            return entity.Id;
        }

        public async Task<int> InsertAndGetIdAsync(T entity, CancellationToken token = default)
        {
            Insert(entity);
            await _dbcontext.SaveChangesAsync(token);
            return entity.Id;
        }

        public void Update(T entity)
        {
            _dbcontext.SaveChanges();
        }

        public async Task UpdateAsync(T entity)
        {
            await _dbcontext.SaveChangesAsync();
        }

        public void Delete(int id)
        {
            var entity = entities.SingleOrDefault(x => x.Id == id);
            if (entity == null)
            {
                throw new EntityNotFoundException(id, typeof(T));
            }
            entities.Remove(entity);
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await entities.SingleOrDefaultAsync(x => x.Id == id);
            if (entity == null)
            {
                throw new EntityNotFoundException(id, typeof(T));
            }
            entities.Remove(entity);
        }

        public void SaveChanges()
        {
            try
            {
                _dbcontext.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                ex.Entries.Single().Reload();
                throw new ConcurrencyException();
            }
        }

        public async Task SaveChangesAsync()
        {
            try
            {
                await _dbcontext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                ex.Entries.Single().Reload();
                throw new ConcurrencyException();
            }
        }

        public IQueryable<T> Get()
        {
            return entities.AsQueryable();
        }
    }
}
