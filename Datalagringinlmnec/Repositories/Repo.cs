﻿using Datalagringinlmnec.Contexts;
using System.Linq.Expressions;

namespace Datalagringinlmnec.Repositories;

internal class Repo<TEntity> where TEntity : class
{
    private readonly DatabseCotext _context;

    public Repo(DatabseCotext context)
    {
        _context = context;
    }

    public TEntity Create(TEntity entity)
    {
        try
        {
            _context.Set<TEntity>().Add(entity);
            _context.SaveChanges();
            return entity;
        }
        catch (Exception ex) { Console.WriteLine(ex); }
        return null!;
    }

    public IEnumerable<TEntity> GetAll()
    {
        try
        {
            return _context.Set<TEntity>().ToList();
        }
        catch (Exception ex) { Console.WriteLine(ex.Message); }
        return null!;
    }

    public TEntity Get(Expression<Func<TEntity, bool>> expression)
    {
        try
        {
            var entity = _context.Set<TEntity>().FirstOrDefault(expression);
            return entity!;
        }
        catch (Exception ex) { Console.WriteLine(ex.Message); }
        return null!;
    }

    public TEntity Update(Expression<Func<TEntity, bool>> expression, TEntity entity)
    {
        try
        {
            var toUpdate = _context.Set<TEntity>().FirstOrDefault(expression);
            _context.Entry(toUpdate!).CurrentValues.SetValues(entity);
            _context.SaveChanges();
            return toUpdate!;
        }
        catch (Exception ex) { Console.WriteLine(ex.Message); }
        return null!;
    }

    public void Delete(Expression<Func<TEntity, bool>> expression)
    {
        try
        {
            var entity = _context.Set<TEntity>().FirstOrDefault(expression);
            _context.Remove(entity!);
        }
        catch (Exception ex) { Console.WriteLine(ex.Message);}
    }
}