using Common.Entities;
using Core.Interfaces;
using Mango.Service.CartAPI;

namespace Mango.Service.CartAPI.Repository;

public static class RepositoryFactory
{
    public static IGenericRepository<T> CreateRepository<T>(CartDbContext context) where T : BaseEntity
    {
        return new GenericRepository<T>(context);
    }
}
