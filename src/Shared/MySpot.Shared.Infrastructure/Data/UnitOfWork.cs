﻿using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MySpot.Shared.Infrastructure.Data;

public abstract class UnitOfWork<T> : IUnitOfWork where T : DbContext
{
    private readonly T _dbContext;

    protected UnitOfWork(T dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task ExecuteAsync(Func<Task> action)
    {
        await using var transaction = await _dbContext.Database.BeginTransactionAsync();
        try
        {
            await action();
            await _dbContext.SaveChangesAsync();
            await transaction.CommitAsync();
        }
        catch (Exception)
        {
            await transaction.RollbackAsync();
            throw;
        }
    }
}