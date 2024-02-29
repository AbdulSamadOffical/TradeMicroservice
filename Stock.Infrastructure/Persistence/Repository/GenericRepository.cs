﻿using Trade.Domain.RepositoryContracts;
using Trade.Infrastructure.Persistence;
using System.Linq.Expressions;
using System.Net.Http;
using Trade.Domain.Interfaces;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    protected readonly ApplicationContext _context;
 
    public GenericRepository(ApplicationContext context)
    {
        _context = context;
    
    }
    public void Add(T entity)
    {
        _context.Set<T>().Add(entity);
    }

    public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
    {
        return _context.Set<T>().Where(expression);
    }
    public IEnumerable<T> GetAll()
    {
        return _context.Set<T>().ToList();
    }
    public T GetById(string id)
    {
        return _context.Set<T>().Find(id);
    }
    public void Remove(T entity)
    {
        _context.Set<T>().Remove(entity);
    }
    public void RemoveRange(IEnumerable<T> entities)
    {
        _context.Set<T>().RemoveRange(entities);
    }
 
}