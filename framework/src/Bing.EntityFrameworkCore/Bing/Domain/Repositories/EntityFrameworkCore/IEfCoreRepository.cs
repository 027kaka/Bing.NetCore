using System;
using Bing.Domain.Entities;

namespace Bing.Domain.Repositories.EntityFrameworkCore
{
    public interface IEfCoreRepository<TEntity> : IEfCoreRepository<TEntity, Guid>
        where TEntity : class, IAggregateRoot, IKey<Guid>
    {

    }

    public interface IEfCoreRepository<TEntity, in TKey> : IRepository<TEntity, TKey> where TEntity : class, IAggregateRoot, IKey<TKey>
    {
    }
}
