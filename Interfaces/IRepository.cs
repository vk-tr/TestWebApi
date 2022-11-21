using System;
using System.Linq;

namespace TestWebApi.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : IHaveId
    {
        IQueryable<TEntity> GetAll();

        void Remove(TEntity entity);

        void Add(TEntity entity);
    }
}