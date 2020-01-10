﻿using Infra.Config;
using Infra.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infra.Repository
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        private readonly DbContext _context;

        protected Repository(DbContext context)
        {
            _context = context;
        }

        public bool Add(T entity)
        {
            try
            {
                _context.Set<T>().Add(entity).State = EntityState.Added;
                return _context.SaveChanges() > 0;
            }
            catch(DbUpdateException ex)
            {
                throw ex;
            }
        }

        public IEnumerable<T> GetAll()
        {
            try
            {
                return _context.Set<T>().ToList();
            }
            catch (ArgumentNullException ex)
            {
                throw ex;
            }
        }

        public T GetById(int id)
        {
            try
            {
                return _context.Set<T>().Find(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Remove(T entity)
        {
            try
            {
                _context.Set<T>().Remove(entity).State = EntityState.Deleted;
                return _context.SaveChanges() > 0;
            }
            catch (DbUpdateException ex)
            {
                throw ex;
            }
        }

        public bool Update(T entity)
        {
            try
            {
                _context.Set<T>().Update(entity).State = EntityState.Modified;
                return _context.SaveChanges() > 0;
            }
            catch (DbUpdateException ex)
            {
                throw ex;
            }
        }
    }
}