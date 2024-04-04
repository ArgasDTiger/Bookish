﻿using Core.Entities;
using Core.Interfaces;
using CSharpVitamins;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
{
    private readonly BooksContext _context;

    public Repository(BooksContext context)
    {
        _context = context;
    }
    
    public async Task<List<TEntity>> GetAllAsync()
    {
        return await _context.Set<TEntity>().ToListAsync();
    }

    public async Task<TEntity?> GetByIdAsync(ShortGuid id)
    {
        return await _context.Set<TEntity>().FirstOrDefaultAsync(i => i.Id == id);
    }

    public async Task<bool> DeleteAsync(ShortGuid id)
    {
        var item = await _context.Set<TEntity>().FirstOrDefaultAsync(i => i.Id == id);
        
        if (item == null) return false;
        
        _context.Set<TEntity>().Remove(item);
        
        return await SaveAsync();

    }

    public async Task AddAsync(TEntity item)
    {
        await _context.Set<TEntity>().AddAsync(item);
        await SaveAsync();
    }

    public async Task Update(TEntity item)
    {
        _context.Set<TEntity>().Update(item);
        await SaveAsync();
    }

    public async Task<bool> SaveAsync()
    {
        var saved = await _context.SaveChangesAsync();
        return saved > 0;
    }
}