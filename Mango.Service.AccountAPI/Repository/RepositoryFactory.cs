using Common.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Mango.Service.AccountAPI.Repository;

public static class RepositoryFactory
{
    public static IGenericRepository<T> CreateRepository<T>(AccountDbContext context) where T : BaseEntity
    {
        return new GenericRepository<T>(context);
    }
}
