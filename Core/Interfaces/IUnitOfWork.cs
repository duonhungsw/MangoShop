﻿using Common.Entities;
using Core.Interfaces;

namespace Book.Core.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IGenericRepository<T> Repository<T>() where T : BaseEntity;
    Task<bool> Complete();
}
