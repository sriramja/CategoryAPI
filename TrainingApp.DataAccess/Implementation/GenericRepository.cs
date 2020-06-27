using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TrainingApp.DataAccess.Contract;

namespace TrainingApp.DataAccess.Implementation
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {

        private readonly ApplicationContext context;
        private readonly DbSet<T> dbSet;
        public GenericRepository(ApplicationContext context)
        {
            this.context = context;
            this.dbSet = context.Set<T>();
        }


        public virtual T GetById(int id)
        {
            return dbSet.Find(id);
        }
        public virtual void Add(T entity)
        {
            dbSet.Add(entity);
            context.SaveChanges();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await context.Set<T>().ToListAsync();
        }


        public virtual void Remove(int id)
        {
            T entityToDelete = dbSet.Find(id);
            Remove(entityToDelete);
        }

        public virtual void Remove(T entityToDelete)
        {
            if (context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
        }
        public virtual void Update(T entity)
        {
            dbSet.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }
        //public Task Update(T entity)
        //{

        //    context.Entry(entity).State = EntityState.Modified;
        //    return context.SaveChangesAsync();
        //}
    }
}

