using BLL.Interfaces;
using DAL.Context;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Repository
{
    public class GenaricRepository<T> : IGenaricRepository<T> where T : class
    {
        private readonly KianDbContext context;

        public GenaricRepository(KianDbContext context)
        {
            this.context = context;
        }
        public async Task Add(T entity)
            => await context.Set<T>().AddAsync(entity);

        public T Delete(T Entity)
        {
          return  context.Set<T>().Remove(Entity).Entity;
        }

        public async Task<IReadOnlyList<T>> getallemployees()
        {
            return await context.Set<T>().ToListAsync();
        }

        public async Task SaveChanges()
        {
            await context.SaveChangesAsync();
        }

        public async Task<T> search(int ? id)
        {
            
            return await context.Set<T>().FindAsync(id);
        }

        public T Update(T obj)
        {
           return context.Set<T>().Update(obj).Entity;
        }
        
    }
}
