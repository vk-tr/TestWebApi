using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TestWebApi.Contexts;
using TestWebApi.Interfaces;

namespace TestWebApi.Services
{
    public sealed class Repository<TEntity> : IRepository<TEntity> where TEntity : class, IHaveId
    {
        private DataBaseContext _context;
        public Repository(DataBaseContext context)
        {
            _context = context;
        }
        private DbSet<TEntity>? DbSet => _context.Set<TEntity>();

        public IQueryable<TEntity>? GetAll()
        {
            var dbSet = _context.Set<TEntity>();
            return DbSet?.AsQueryable();
        }
        public void Remove(TEntity entity)
        {
            DbSet?.Remove(entity);
            _context.SaveChanges();
        }
        public void Add(TEntity entity)
        {
            DbSet?.Add(entity);
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