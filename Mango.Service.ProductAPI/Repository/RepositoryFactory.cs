using Common.Entities;
using Core.Interfaces;

namespace Mango.Service.ProductAPI.Repository;

public static class RepositoryFactory
{
    public static IGenericRepository<T> CreateRepository<T>(ProductDbContext context) where T : BaseEntity
    {
        return new GenericRepository<T>(context);
    }
}
