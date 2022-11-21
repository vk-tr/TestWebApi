using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TestWebApi.Contexts;
using TestWebApi.Interfaces;

namespace TestWebApi.Services
{
    public sealed class Repository : IRepository
    {
        private DataBaseContext _context;
        public Repository(DataBaseContext context)
        {
            _context = context;
        }

        public IQueryable<TEntity> GetAll<TEntity>() where TEntity : class, IHaveId
        {
            var dbSet = _context.Set<TEntity>();
            return dbSet.AsQueryable();
        }

        public void Remove<TEntity>(TEntity entity) where TEntity : class, IHaveId
        {
            var dbSet = _context.Set<TEntity>();
            dbSet.Remove(entity);

            _context.SaveChanges();
        }

        public void Add<TEntity>(TEntity entity) where TEntity : class, IHaveId
        {
            var dbSet = _context.Set<TEntity>();
            dbSet.Add(entity);

            _context.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context?.Dispose();
                _context = null;
            }
        }
    }
}