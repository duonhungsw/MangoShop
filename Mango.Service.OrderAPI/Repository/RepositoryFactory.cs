using Common.Entities;
using Core.Interfaces;

namespace Mango.Service.OrderAPI.Repository;

public static class RepositoryFactory
{
    public static IGenericRepository<T> CreateRepository<T>(OrderDbContext context) where T : BaseEntity
    {
        return new GenericRepository<T>(context);
    }
}
