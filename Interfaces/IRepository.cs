using System;
using System.Linq;

namespace TestWebApi.Interfaces
{
    public interface IRepository : IDisposable
    {
        IQueryable<TEntity> GetAll<TEntity>()
            where TEntity : class, IHaveId;

        void Remove<TEntity>(TEntity entity)
            where TEntity : class ,IHaveId;

        void Add<TEntity>(TEntity entity)
            where TEntity : class, IHaveId;
    }
}